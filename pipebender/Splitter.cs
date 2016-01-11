using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pipebender
{
    abstract class Splitter : Component
    {
        protected int splitterType;
        protected int flowIn = 0;
        protected int flowOut1 = 0, flowOut2 = 0;
        protected int isInAvailable = -1;
        protected int isOut1Available = -1;
        protected int isOut2Available = -1;

        public Splitter(int id, Point coord, int splitterType, int eType) : base(id, coord, eType)
        {
            this.Id = id;
            this.Coord = coord;
            this.splitterType = splitterType;
        }

        public int SplitterType
        {
            get
            {
                return splitterType;
            }

            set
            {
                splitterType = value;
            }
        }

        public int IsInAvailable
        {
            get
            {
                return isInAvailable;
            }

            set
            {
                isInAvailable = value;
            }
        }

        public int IsOut1Available
        {
            get
            {
                return isOut1Available;
            }

            set
            {
                isOut1Available = value;
            }
        }

        public int IsOut2Available
        {
            get
            {
                return isOut2Available;
            }

            set
            {
                isOut2Available = value;
            }
        }

        public int GetFlowIn
        {
            get
            {
                return flowIn;
            }

            set
            {
                flowIn = value;
            }
        }

        public int GetFlowOut1
        {
            get
            {
                return flowOut1;
            }

            set
            {
                flowOut1 = value;
            }
        }

        public int GetFlowOut2
        {
            get
            {
                return flowOut2;
            }

            set
            {
                flowOut2 = value;
            }
        }

        override public int isComponentConnectionAvailable(Point p, ImageList iL)
        {
            if (isLeftSide(p, iL))
            {
                return IsInAvailable;
            }
            else
            {
                if (isTopSide( p, iL))
                {
                    return IsOut1Available;
                }
                else
                {
                    return IsOut2Available;
                }
            }
        }

        override public int whatKindOfCoennectionIs(Point p, ImageList iL)
        {
            if (isLeftSide(p, iL))
            {
                return (int)TypeOfConnection.MiddleInput;
            }
            else
            {
                if (isTopSide(p, iL))
                {
                    return (int)TypeOfConnection.TopOutput;
                }
                else
                {
                    return (int)TypeOfConnection.BottomOutput;
                }
            }
        }

        override public void invalidateConnectionValidateConnection(int typeOfConnection, int op)
        {
            if (typeOfConnection == (int)TypeOfConnection.MiddleInput)
            {
                IsInAvailable = op;
            }
            else if (typeOfConnection == (int)TypeOfConnection.TopOutput)
            {
                IsOut1Available = op;
            }
            else if (typeOfConnection == (int)TypeOfConnection.BottomOutput)
            {
                IsOut2Available = op;
            }
        }

        override public abstract void configureValues(ref List<Component> compList, ref List<Pipe> pipeList);

        override public abstract void recalcFlow(ref List<Component> compList, ref List<Pipe> pipeList);

        override public abstract void removeFlowItems(ref List<Component> compList, ref List<Pipe> pipeList);

        override public abstract String giveMeYourValuesInText();

        override public void FlowIn(int typeOfConnection, int flow)
        {
            flowIn = flow;
        }
    }
}
