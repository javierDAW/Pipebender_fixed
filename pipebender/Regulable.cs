using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pipebender
{
    class Regulable : Splitter
    {
        private int percentage = 50;
        private FlowSlider flowSlider;

        public Regulable(int id, Point coord, int splitterType, int percentage, int eType) : base(id, coord, splitterType, eType)
        {
            Id = id;
            Coord = coord;
            this.splitterType = splitterType;
            this.percentage = percentage;
        }

        public int Percentage
        {
            get
            {
                return percentage;
            }

            set
            {
                percentage = value;
            }
        }

        override public void configureValues(ref List<Component> compList, ref List<Pipe> pipeList)
        {
            MessageBox.Show(percentage.ToString());
            flowSlider = new FlowSlider(percentage);

            if (flowSlider.ShowDialog() == DialogResult.OK)
            {
                percentage = flowSlider.TrackSlider.Value;

                recalcFlow(ref compList, ref pipeList);
            }
        }

        override public void recalcFlow(ref List<Component> compList, ref List<Pipe> pipeList) {
            Pipe p1 = pipeList.Find(x => x.EndComponentID == id);
            
            flowIn = p1.CurrentFlow;
            flowOut1 = (percentage * flowIn / 100);
            flowOut2 = ((100 - percentage) * flowIn / 100);

            Pipe p2 = null;
            p2 = pipeList.Find(x => x.ID == isOut1Available);
            if (p2 != null)
            {
                if (p2.MaxFlow > flowOut1 && p2.CurrentFlow != flowOut1)
                {
                    p2.CurrentFlow = flowOut1;

                    Component c = compList.Find(x => x.Id == p2.EndComponentID);

                    c.recalcFlow(ref compList, ref pipeList);
                }
                else if (flowOut1 >= p2.MaxFlow && p2.CurrentFlow != p2.MaxFlow)
                {
                    p2.CurrentFlow = p2.MaxFlow;

                    Component c = compList.Find(x => x.Id == p2.EndComponentID);

                    c.recalcFlow(ref compList, ref pipeList);
                }
            }

            Pipe p3 = null;
            p3 = pipeList.Find(x => x.ID == isOut2Available);
            if (p3 != null)
            {
                if (p3.MaxFlow > flowOut2 && p3.CurrentFlow != flowOut2)
                {
                    p3.CurrentFlow = flowOut2;

                    Component c = compList.Find(x => x.Id == p3.EndComponentID);

                    c.recalcFlow(ref compList, ref pipeList);
                }
                else if (flowOut2 >= p3.MaxFlow && p3.CurrentFlow != p3.MaxFlow)
                {
                    p3.CurrentFlow = p3.MaxFlow;

                    Component c = compList.Find(x => x.Id == p3.EndComponentID);

                    c.recalcFlow(ref compList, ref pipeList);
                }
            }

            if (p1.Removing == true)
                isInAvailable = -1;
            else if (p2.Removing == true)
                isOut1Available = -1;
            else if (p3.Removing == true)
                isOut2Available = -1;
        }

        override public int FlowOut(int typeOfConnection)
        {
            if (typeOfConnection == (int)TypeOfConnection.TopOutput)
            {
                flowOut1 = (percentage * flowIn / 100);
                return flowOut1;
            }
            else
            {
                flowOut2 = ((100 - percentage) * flowIn / 100);
                return flowOut2;
            }
        }

        override public String giveMeYourValuesInText()
        {
            String resume = EType + " " + id + " " + coord.X + " " + coord.Y + " " + splitterType + " " + isInAvailable + " " + isOut1Available + " " + isOut2Available + " " + flowIn + " " + flowOut1 + " " + flowOut2 + " "+percentage;

            return resume;
        }

        public override void removeFlowItems(ref List<Component> compList, ref List<Pipe> pipeList)
        {
            Pipe p1 = null;
            p1 = pipeList.Find(x => x.ID == isInAvailable);

            Pipe p2 = null;
            p2 = pipeList.Find(x => x.ID == isOut1Available);

            Pipe p3 = null;
            p3 = pipeList.Find(x => x.ID == isOut2Available);

            if (p1 != null)
            {
                p1.CurrentFlow = 0;
                p1.Removing = true;

                Component c = compList.Find(x => x.Id == p1.StartComponentID);

                c.recalcFlow(ref compList, ref pipeList);

                pipeList.Remove(p1);
            }

            if (p2 != null)
            {
                p2.CurrentFlow = 0;
                p2.Removing = true;

                Component c = compList.Find(x => x.Id == p2.EndComponentID);

                c.recalcFlow(ref compList, ref pipeList);

                pipeList.Remove(p2);
            }

            if (p3 != null)
            {
                p3.CurrentFlow = 0;
                p3.Removing = true;

                Component c = compList.Find(x => x.Id == p3.EndComponentID);

                c.recalcFlow(ref compList, ref pipeList);

                pipeList.Remove(p3);
            }
            
            compList.Remove(this);
        }

    }
}
