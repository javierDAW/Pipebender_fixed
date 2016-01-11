using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pipebender
{
    class Merger : Component
    {
        private int flowIn1 = 0, flowIn2 = 0;
        private int flowOut = 0;
        private int isIn1Available = -1;
        private int isIn2Available = -1;
        private int isOutAvailable = -1;

        public Merger(int id, Point coord, int eType) : base(id, coord, eType)
        {
            Id = id;
            Coord = coord;
        }

        public int FlowIn1
        {
            get
            {
                return flowIn1;
            }

            set
            {
                flowIn1 = value;
            }
        }

        public int FlowIn2
        {
            get
            {
                return flowIn2;
            }

            set
            {
                flowIn2 = value;
            }
        }

        public int GetFlowOut
        {
            get
            {
                return flowOut;
            }

            set
            {
                flowOut = value;
            }
        }

        public int IsIn1Available
        {
            get
            {
                return isIn1Available;
            }

            set
            {
                isIn1Available = value;
            }
        }

        public int IsIn2Available
        {
            get
            {
                return isIn2Available;
            }

            set
            {
                isIn2Available = value;
            }
        }

        public int IsOutAvailable
        {
            get
            {
                return isOutAvailable;
            }

            set
            {
                isOutAvailable = value;
            }
        }

        override public int isComponentConnectionAvailable(Point p, ImageList iL)
        {
            if (!isLeftSide(p, iL))
            {
                return IsOutAvailable;
            }
            else
            {
                if (isTopSide(p, iL))
                {
                    return IsIn1Available;
                }
                else
                {
                    return IsIn2Available;
                }
            }
        }

        override public int whatKindOfCoennectionIs(Point p, ImageList iL)
        {
            if (!isLeftSide(p, iL))
            {
                return (int)TypeOfConnection.MiddleOutput;
            }
            else
            {
                if (isTopSide(p, iL))
                {
                    return (int)TypeOfConnection.TopInput;
                }
                else
                {
                    return (int)TypeOfConnection.BottomInput;
                }
            }
        }

        override public void invalidateConnectionValidateConnection(int typeOfConnection, int op)
        {
            if (typeOfConnection == (int)TypeOfConnection.TopInput)
            {
                IsIn1Available = op;
            }
            else if (typeOfConnection == (int)TypeOfConnection.BottomInput)
            {
                IsIn2Available = op;
            }
            else
            {
                IsOutAvailable = op;
            }
        }

        override public void configureValues(ref List<Component> compList, ref List<Pipe> pipeList)
        {
            MessageBox.Show("Nothing can be configured here");
        }

        override public void recalcFlow(ref List<Component> compList, ref List<Pipe> pipeList) {
            Pipe p1 = null;
            p1 = pipeList.Find(x => x.ID == isIn1Available);

            Pipe p2 = null;
            p2 = pipeList.Find(x => x.ID == isIn2Available);

            if (p1 != null && p2 != null)
            {
                flowIn1 = p1.CurrentFlow;
                flowIn2 = p2.CurrentFlow;
                flowOut = flowIn1 + flowIn2;
            }
            else if (p1 != null && p2 == null)
            {
                flowIn1 = p1.CurrentFlow;
                flowOut = flowIn1;
            }
            else if (p1 == null && p2 != null)
            {
                flowIn2 = p2.CurrentFlow;
                flowOut = flowIn2;
            }

            Pipe p3 = null;
            p3 = pipeList.Find(x => x.ID == isOutAvailable);
            if (p3 != null)
            {
                if (p3.MaxFlow > flowOut && p3.CurrentFlow != flowOut)
                {
                    p3.CurrentFlow = flowOut;

                    Component c = compList.Find(x => x.Id == p3.EndComponentID);

                    c.recalcFlow(ref compList, ref pipeList);
                }
                else if (flowOut >= p3.MaxFlow && p3.CurrentFlow != p3.MaxFlow)
                {
                    p3.CurrentFlow = p3.MaxFlow;

                    Component c = compList.Find(x => x.Id == p3.EndComponentID);

                    c.recalcFlow(ref compList, ref pipeList);
                }
            }
        }

        override public void FlowIn(int typeOfConnection, int flow)
        {
            if(typeOfConnection == (int)TypeOfConnection.TopInput)
            {
                flowIn1 = flow;
            }
            else
            {
                flowIn2 = flow;
            }
        }

        override public int FlowOut(int typeOfConnection)
        {
            flowOut = flowIn1 + flowIn2;
            return flowOut;
        }

        override public String giveMeYourValuesInText()
        {
            String resume = EType + " " + id + " " + coord.X + " " + coord.Y+ " "+isIn1Available+" "+isIn2Available+ " "+ isOutAvailable+ " "+flowIn1+" "+flowIn2+ " "+flowOut;
            return resume;
        }

        public override void removeFlowItems(ref List<Component> compList, ref List<Pipe> pipeList)
        {
            Pipe p1 = null;
            p1 = pipeList.Find(x => x.ID == isIn1Available);

            Pipe p2 = null;
            p2 = pipeList.Find(x => x.ID == isIn2Available);

            Pipe p3 = null;
            p3 = pipeList.Find(x => x.ID == isOutAvailable);

            if(p1 != null)
            {
                Component c = compList.Find(x => x.Id == p1.StartComponentID);

                pipeList.Remove(p1);

                c.removeFlowItems(ref compList, ref pipeList);
            }

            if (p2 != null)
            {
                Component c = compList.Find(x => x.Id == p2.StartComponentID);

                pipeList.Remove(p2);

                c.removeFlowItems(ref compList, ref pipeList);
            }

            if (p3 != null)
            {
                Component c = compList.Find(x => x.Id == p3.EndComponentID);

                pipeList.Remove(p3);

                c.removeFlowItems(ref compList, ref pipeList);
            }

            compList.Remove(this);
        }
    }
}
