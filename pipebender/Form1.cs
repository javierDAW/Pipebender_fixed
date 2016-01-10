using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pipebender
{
    public partial class Form1 : Form
    {
        private int typeC = 7;
        private ComponentTable ct;
        private int id = 0;
        private int pipeId = 0;
        private Pipe p = null;
        private List<Point> pipesCoordAux = null;
        private int idStart = -1, idEnd = -1;
        private int typeOfConnectionStart = -1;
        private int typeOfConnectionEnd = -1;
        private AskFlow pipeFlowForm;
        private int pipeFlow;
        private int currentFlow = 0;
        private ModelClass m;
        private String PathFile = null;

        public Form1()
        {
            InitializeComponent();
            ct = new ComponentTable();
        }

        private void pumpBtn_Click(object sender, EventArgs e)
        {
            typeC = (int)EnumTypes.Pump; // Events to detect which botton you clicked so which object you want to draw.
            cleanValues();
        }

        private void sinkBtn_Click(object sender, EventArgs e)
        {
            typeC = (int)EnumTypes.Sink;
            cleanValues();
        }

        private void mergerBtn_Click(object sender, EventArgs e)
        {
            typeC = (int)EnumTypes.Merger;
            cleanValues();
        }

        private void normalSplitterBtn_Click(object sender, EventArgs e)
        {
            typeC = (int)EnumTypes.Normal;
            cleanValues();
        }

        private void regSplitterBtn_Click(object sender, EventArgs e)
        {
            typeC = (int)EnumTypes.Regulable;
            cleanValues();
        }

        private void mapBox_Paint(object sender, PaintEventArgs e)
        {
            ct.DrawComponents(e.Graphics, menuImages); // Drawing components on e
            ct.drawpipes(e.Graphics, menuImages);
        }

        private void mapBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                leftClickBehaviour(sender, e);
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                rightClickBehaviour(sender, e);
            }
        }

        private void leftClickBehaviour(object sender, MouseEventArgs e)
        {
            //You cannot click outside of the mapbox
            if (((e.X + menuImages.Images[0].Width < mapBox.Width) && (e.Y + menuImages.Images[0].Height < mapBox.Height)) || typeC == (int)EnumTypes.Pipe)
            {
                if (ct.OverlappingComp(e.Location, menuImages) != -1 && typeC <= (int)EnumTypes.Merger)
                {
                    MessageBox.Show("There cannot be an overlapping of components!");
                }
                else
                {
                    Component c1 = null; // Creating a Component object in order to use the heritage (subcomponents)

                    switch (typeC) // Switching between type of Component in order to place the different images depending on the clicked button
                    {
                        case (int)EnumTypes.Sink:
                            // Creating the new object (Sick in this case) - The (int)EnumTypes.Sink uses the enum created so you don't need to remember which number is it each type.
                            c1 = new Sink(id, e.Location, 20, (int)EnumTypes.Sink);
                            break;

                        case (int)EnumTypes.Pump:
                            c1 = new Pump(id, e.Location, (int)EnumTypes.Pump);
                            break;

                        case (int)EnumTypes.Merger:
                            c1 = new Merger(id, e.Location, (int)EnumTypes.Merger);
                            break;

                        case (int)EnumTypes.Regulable:
                            c1 = new Regulable(id, e.Location, 1, 50, (int)EnumTypes.Regulable);
                            break;

                        case (int)EnumTypes.Normal:
                            c1 = new Normal(id, e.Location, 0, (int)EnumTypes.Normal);
                            break;

                        case (int)EnumTypes.Pipe:
                            if (idStart == -1)
                            {
                                int resulStart = ct.pointOverlappingComp(e.Location, menuImages);
                                if (resulStart != -1)
                                {
                                    if (ct.isComponentConnectionAvailable(resulStart, e.Location, menuImages) == -1)
                                    {
                                        idStart = resulStart;
                                        typeOfConnectionStart = ct.whatKindOfCoennectionIs(idStart, e.Location, menuImages);
                                    }
                                    else
                                    {
                                        MessageBox.Show(ct.isComponentConnectionAvailable(resulStart, e.Location, menuImages).ToString());
                                        cleanValues();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("You should click ontop of a component");
                                    cleanValues();
                                }
                            }
                            else
                            {
                                int resulEnd = ct.pointOverlappingComp(e.Location, menuImages);
                                if (resulEnd != -1 && (idStart != resulEnd))
                                {
                                    if (ct.isComponentConnectionAvailable(resulEnd, e.Location, menuImages) == -1)
                                    {
                                        idEnd = resulEnd;
                                        typeOfConnectionEnd = ct.whatKindOfCoennectionIs(idEnd, e.Location, menuImages);

                                        if (ct.isTheConecctionPossible(typeOfConnectionStart, typeOfConnectionEnd))
                                        {
                                            pipeFlowForm = new AskFlow((int)EnumTypes.Pipe);

                                            if (pipeFlowForm.ShowDialog(this) == DialogResult.OK)
                                            {
                                                pipeFlow = (int)pipeFlowForm.GetFlow.Value;

                                                if (pipesCoordAux == null)
                                                {
                                                    p = new Pipe(idStart, idEnd, typeOfConnectionStart, typeOfConnectionEnd, pipeId, pipeFlow);
                                                }
                                                else
                                                {
                                                    p = new Pipe(idStart, idEnd, typeOfConnectionStart, typeOfConnectionEnd, pipesCoordAux, pipeId, pipeFlow);
                                                }

                                                if (!ct.pipeOverlappingComponent(p, menuImages))
                                                {
                                                    //makeConnectionInaccessible
                                                    ct.invalidateConnection(idStart, typeOfConnectionStart, pipeId);
                                                    ct.invalidateConnection(idEnd, typeOfConnectionEnd, pipeId);
                                                    ct.PipeList.Add(p);
                                                    pipeId++;

                                                    // Inserting the flow into the different components
                                                    currentFlow = ct.FlowOut(idStart, typeOfConnectionStart, pipeId);
                                                    //MessageBox.Show(currentFlow.ToString());
                                                    if (currentFlow >= p.MaxFlow)
                                                    {
                                                        p.CurrentFlow = p.MaxFlow;
                                                    }
                                                    else
                                                    {
                                                        p.CurrentFlow = currentFlow;
                                                    }

                                                    ct.FlowIn(idEnd, typeOfConnectionEnd, pipeId, p.CurrentFlow);
                                                    // End

                                                    cleanValues();

                                                }
                                                else
                                                {
                                                    MessageBox.Show("This pipe is overlapping a component");
                                                    cleanValues();
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Cancelled!");
                                            }

                                            pipeFlowForm.Dispose();
                                        }
                                        else
                                        {
                                            MessageBox.Show("This kind of connection isn´t possible");
                                            cleanValues();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show(ct.isComponentConnectionAvailable(resulEnd, e.Location, menuImages).ToString());
                                        cleanValues();
                                    }
                                }
                                else
                                {
                                    if (pipesCoordAux == null)
                                    {
                                        pipesCoordAux = new List<Point>();
                                        pipesCoordAux.Add(e.Location);
                                    }
                                    else
                                    {
                                        pipesCoordAux.Add(e.Location);
                                    }
                                }
                            }
                            break;

                        case (int)EnumTypes.Remove:
                            ct.RemoveComp(e.Location, menuImages);
                            break;

                        default:
                            break;
                    }

                    if (c1 != null)
                    {
                        id++; // Increments the id of component
                        ct.CompList.Add(c1); // Adding component to the List in the ComponentTable.
                    }
                    else if (c1 == null && typeC > (int)EnumTypes.Pipe)
                    { // If theres no component created and the typeC is out from the component range
                        if (typeC != (int)EnumTypes.Remove)
                            MessageBox.Show("Error selecting object.");
                    }
                }
                Refresh();
            }
        }

        private void rightClickBehaviour(object sender, MouseEventArgs e)
        {
            int resul = ct.pointOverlappingComp(e.Location, menuImages);
            if (resul != -1)
            {
                ct.showConfigureOptions(resul);
                mapBox.Refresh();
            }
        }

        private void changeWholeFlow(int id, MouseEventArgs e)
        {
            Component c = ct.CompList.Find(x => x.Id == id);

            if (c.isComponentConnectionAvailable(e.Location, menuImages) != -1)
            {

            }

            mapBox.Refresh();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Component c in ct.CompList)
            {
                MessageBox.Show(c.Id.ToString());
            }
        }

        private void removeBtn(object sender, EventArgs e)
        {
            typeC = (int)EnumTypes.Remove;
            cleanValues();
        }

        private void buttonPipe_Click(object sender, EventArgs e)
        {
            typeC = (int)EnumTypes.Pipe;
            cleanValues();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            m = new ModelClass();
            StreamReader sr = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    PathFile = openFileDialog1.FileName;
                    sr = new StreamReader(openFileDialog1.FileName);
                    m.openFile(ct, sr);
                    id = ++m.Id;
                    pipeId = ++m.IdPipe;
                    buttonSave.Enabled = true;
                    Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading file: " + ex.Message);
                }
                finally
                {
                    sr.Close();
                }
            }
        }

        private void buttonSaveAs_Click(object sender, EventArgs e)
        {
            m = new ModelClass();
            StreamWriter sw = null; ;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    PathFile = saveFileDialog1.FileName;
                    sw = new StreamWriter(saveFileDialog1.FileName);
                    m.saveFile(ct, sw);
                    sw.Close();
                    buttonSave.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error writing file: " + ex.Message);
                }
                finally
                {
                    sw.Close();
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            m = new ModelClass();
            StreamWriter sw = null; ;

            try
            {
                sw = new StreamWriter(PathFile);
                m.saveFile(ct, sw);
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error writing file: " + ex.Message);
            }
            finally
            {
                sw.Close();
            }
        }

        private void cleanValues()
        {
            idStart = -1;
            idEnd = -1;
            typeOfConnectionStart = -1;
            typeOfConnectionEnd = -1;
            pipesCoordAux = null;
            p = null;
        }
    }
}
