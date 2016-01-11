
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pipebender
{
    class ComponentTable
    {
        private List<Component> compList;
        private List<Pipe> pipeList;
        private bool XPosition = false;
        private bool YPosition = true;

        public ComponentTable()
        {
            CompList = new List<Component>();
            pipeList = new List<Pipe>();
        }

        internal List<Pipe> PipeList
        {
            get
            {
                return pipeList;
            }

            set
            {
                pipeList = value;
            }
        }

        internal List<Component> CompList
        {
            get
            {
                return compList;
            }

            set
            {
                compList = value;
            }
        }

        public void showConfigureOptions(int id)
        {
            try
            {
                Component c = compList.Find(x => x.Id == id);
                c.configureValues(ref compList, ref pipeList);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        public int isComponentConnectionAvailable(int id, Point coord, ImageList il)
        {
            try
            {
                Component c = compList.Find(x => x.Id == id);
                return c.isComponentConnectionAvailable(coord, il);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return -1;
            }
        }

        public int whatKindOfCoennectionIs(int id, Point coord, ImageList il)
        {
            try
            {
                Component c = compList.Find(x => x.Id == id);
                return c.whatKindOfCoennectionIs(coord, il);

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return -1;
            }
        }

        public void invalidateConnection(int id, int typeOfConnection, int pipeId)
        {
            try
            {

                Component c = compList.Find(x => x.Id == id);
                c.invalidateConnectionValidateConnection(typeOfConnection, pipeId);

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);

            }
        }

        public void DrawComponents(Graphics gr, ImageList iL)
        {
            foreach (Component c in CompList)
            {
                // Draw the img from the list depending on the Etype on the coordinates stored in the object.
                gr.DrawImage(iL.Images[c.EType], c.Coord.X, c.Coord.Y);

                if (c is Pump || c is Merger)
                {
                    string drawString = c.FlowOut((int)TypeOfConnection.MiddleOutput).ToString();
                    Font drawFont = new Font(
                        "Arial", 16);
                    SolidBrush drawBrush = new SolidBrush(Color.Orange);
                    gr.DrawString(drawString, drawFont, drawBrush, c.Coord.X, c.Coord.Y);
                    drawFont.Dispose();
                    drawBrush.Dispose();
                }
            }


        }

        public void drawpipes(Graphics gr, ImageList iL)
        {
            foreach (Pipe p in pipeList)
            {

                try
                {
                    //Draw the pipes
                    Color myColor;
                    myColor = Color.FromArgb(0, 162, 232);
                    Pen pen;

                    if (p.CurrentFlow < p.MaxFlow)
                        pen = new Pen(myColor, 6);
                    else
                        pen = new Pen(Brushes.Red, 6);

                    Component c1 = compList.Find(x => x.Id == p.StartComponentID);
                    Component c2 = compList.Find(x => x.Id == p.EndComponentID);

                    Point start = new Point(c1.Coord.X, c1.Coord.Y);
                    Point end = new Point(c2.Coord.X, c2.Coord.Y);

                    //MessageBox.Show(whatKindOfCoennectionIs(p.StartComponentID, end, iL).ToString());

                    string drawString = p.CurrentFlow.ToString();
                    Font drawFont = new Font(
                        "Arial", 16);
                    SolidBrush drawBrush = new SolidBrush(Color.Orange);

                    if (p.PointOfPipe == null)
                    {
                        //Draws the line in the right position
                        gr.DrawLine(pen, start.X + modifyPosition(p.StartType, XPosition), start.Y + modifyPosition(p.StartType, YPosition), end.X + modifyPosition(p.EndType, XPosition), end.Y + modifyPosition(p.EndType, YPosition));


                        gr.DrawString(drawString, drawFont, drawBrush, (start.X + end.X) / 2, (start.Y + end.Y) / 2);

                    }
                    else
                    {
                        int arrC = 0;

                        int arrS = p.PointOfPipe.Count / 2;

                        foreach (Point point in p.PointOfPipe)
                        {
                            if (arrC == 0)
                            {
                                gr.DrawLine(pen, start.X + modifyPosition(p.StartType, XPosition), start.Y + modifyPosition(p.StartType, YPosition), point.X, point.Y);
                            }
                            else
                            {
                                gr.DrawLine(pen, start.X, start.Y, point.X, point.Y);
                            }
                            start = point;

                            arrC++;

                            if (arrS == 0)
                            {
                                gr.DrawString(drawString, drawFont, drawBrush, start.X, start.Y);
                            }
                            else if (arrC == arrS)
                            {
                                gr.DrawString(drawString, drawFont, drawBrush, start.X, start.Y);
                            }
                        }
                        gr.DrawLine(pen, start.X, start.Y, end.X + modifyPosition(p.EndType, XPosition), end.Y + modifyPosition(p.EndType, YPosition));
                    }

                    drawFont.Dispose();
                    drawBrush.Dispose();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
        }

        public bool pipeOverlappingComponent(Pipe p, ImageList iL)
        {
            Point p1 = new Point(compList.Find(x => x.Id == p.StartComponentID).Coord.X, compList.Find(x => x.Id == p.StartComponentID).Coord.Y);
            Point p2 = new Point(compList.Find(x => x.Id == p.EndComponentID).Coord.X, compList.Find(x => x.Id == p.EndComponentID).Coord.Y);

            foreach (Component c in CompList)
            {
                if (c.Id != p.StartComponentID && c.Id != p.EndComponentID)
                {
                    Rectangle r = new Rectangle(c.Coord.X, c.Coord.Y, iL.Images[0].Width, iL.Images[0].Height);

                    if (LineIntersectsLine(p1, p2, new Point(r.X, r.Y), new Point(r.X + r.Width, r.Y)) ||
                  LineIntersectsLine(p1, p2, new Point(r.X + r.Width, r.Y), new Point(r.X + r.Width, r.Y + r.Height)) ||
                  LineIntersectsLine(p1, p2, new Point(r.X + r.Width, r.Y + r.Height), new Point(r.X, r.Y + r.Height)) ||
                  LineIntersectsLine(p1, p2, new Point(r.X, r.Y + r.Height), new Point(r.X, r.Y)) ||
                  (r.Contains(p1) && r.Contains(p2)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool LineIntersectsLine(Point l1p1, Point l1p2, Point l2p1, Point l2p2)
        {
            float q = (l1p1.Y - l2p1.Y) * (l2p2.X - l2p1.X) - (l1p1.X - l2p1.X) * (l2p2.Y - l2p1.Y);
            float d = (l1p2.X - l1p1.X) * (l2p2.Y - l2p1.Y) - (l1p2.Y - l1p1.Y) * (l2p2.X - l2p1.X);

            if (d == 0)
            {
                return false;
            }

            float r = q / d;

            q = (l1p1.Y - l2p1.Y) * (l1p2.X - l1p1.X) - (l1p1.X - l2p1.X) * (l1p2.Y - l1p1.Y);
            float s = q / d;

            if (r < 0 || r > 1 || s < 0 || s > 1)
            {
                return false;
            }

            return true;
        }

        //Increments the X and Y values in order to draw the pipes in their right position.
        private int modifyPosition(int t, Boolean XorY)
        {
            switch (t)
            {
                case (int)TypeOfConnection.MiddleOutput:
                    if (!XorY)
                    {
                        return 38;
                    }
                    else
                    {
                        return 20;
                    }
                case (int)TypeOfConnection.MiddleInput:
                    if (!XorY)
                    {
                        return 0;
                    }
                    else
                    {
                        return 20;
                    }

                case (int)TypeOfConnection.TopOutput:
                    if (!XorY)
                    {
                        return 38;
                    }
                    else
                    {
                        return 10;
                    }
                case (int)TypeOfConnection.BottomOutput:
                    if (!XorY)
                    {
                        return 38;
                    }
                    else
                    {
                        return 30;
                    }
                case (int)TypeOfConnection.TopInput:
                    if (!XorY)
                    {
                        return 0;
                    }
                    else
                    {
                        return 10;
                    }
                case (int)TypeOfConnection.BottomInput:
                    if (!XorY)
                    {
                        return 0;
                    }
                    else
                    {
                        return 30;
                    }
                default:
                    return 0;
            }
        }

        //We will check if it´s compatible to connect both of the components selected by user.For instance, you cannot connect the inputs of the merger with the sink.
        public bool isTheConecctionPossible(int aComponent, int bComponent)
        {
            if ((changeTypeofConnectionValueforBooleanValue(aComponent) + changeTypeofConnectionValueforBooleanValue(bComponent)) == 1)
            {
                return true;
            }
            else
                return false;
        }

        //returns a boolean value from the TypeOfConection value
        private int changeTypeofConnectionValueforBooleanValue(int value)
        {
            switch (value)
            {
                case (int)TypeOfConnection.MiddleOutput:

                    return 1;

                case (int)TypeOfConnection.MiddleInput:

                    return 0;

                case (int)TypeOfConnection.TopOutput:

                    return 1;

                case (int)TypeOfConnection.BottomOutput:

                    return 1;

                case (int)TypeOfConnection.TopInput:

                    return 0;

                case (int)TypeOfConnection.BottomInput:

                    return 0;

                default:
                    return 0;
            }
        }

        public int OverlappingComp(Point e, ImageList iL)
        {
            int intersection = -1;
            // Creating a rectangle with the area of the Component and in the same place.
            Rectangle aux = new Rectangle(e.X, e.Y, iL.Images[0].Width, iL.Images[0].Height);

            foreach (Component c in CompList)
            {
                // Comparing the created rectangle another new one created for each element
                Rectangle recAux = new Rectangle(c.Coord.X, c.Coord.Y, iL.Images[0].Width, iL.Images[0].Height);

                // If they touch each other -> win
                if (recAux.IntersectsWith(aux))
                    intersection = c.Id;
            }

            return intersection;
        }

        public int pointOverlappingComp(Point e, ImageList iL)
        {
            int intersection = -1;

            foreach (Component c in CompList)
            {
                // Comparing the created rectangle another new one created for each element
                Rectangle recAux = new Rectangle(c.Coord.X, c.Coord.Y, iL.Images[0].Width, iL.Images[0].Height);

                // If they touch each other -> win
                if (recAux.Contains(e))
                    intersection = c.Id;
            }

            return intersection;
        }

        public void RemoveComp(Point e, ImageList iL)
        {
            for (int i = 0; i < compList.Count; i++)
            {
                Rectangle recAux = new Rectangle(compList[i].Coord.X, compList[i].Coord.Y, iL.Images[0].Width, iL.Images[0].Height);

                if (recAux.Contains(e))
                {
                    compList[i].removeFlowItems(ref compList, ref pipeList);
                }
            }
        }

        public void FlowIn(int id, int typeOfConnection, int pipeId, int flow)
        {
            try
            {

                Component c = compList.Find(x => x.Id == id);
                c.FlowIn(typeOfConnection, flow);

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);

            }
        }

        public int FlowOut(int id, int typeOfConnection, int pipeId)
        {
            try
            {

                Component c = compList.Find(x => x.Id == id);
                return c.FlowOut(typeOfConnection);

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);

            }

            return -1;
        }
    }
}
