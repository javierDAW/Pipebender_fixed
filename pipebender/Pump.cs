using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pipebender
{
    class Pump : Component
    {
        private int flow = 38; // This is default flow. We can change it later.
        private int isOutAvailable = -1;
        private AskFlow flowForm;

        public Pump(int id, Point coord, int eType) : base(id, coord, eType)
        {
            Id = id;
            Coord = coord;
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

        public int Flow
        {
            get
            {
                return flow;
            }

            set
            {
                flow = value;
            }
        }

        override public int isComponentConnectionAvailable(Point p, ImageList iL) 
        {
            return isOutAvailable;
        }

        override public int whatKindOfCoennectionIs(Point p, ImageList iL)
        {
            return (int)TypeOfConnection.MiddleOutput;
        }

        override public void invalidateConnectionValidateConnection(int typeOfConnection, int op)
        {
            isOutAvailable = op;
        }

        override public void configureValues(ref List<Component> compList, ref List<Pipe> pipeList)
        {
            flowForm = new AskFlow((int)EnumTypes.Pump);
           
            if (flowForm.ShowDialog() == DialogResult.OK)
            {
                flow = (int)flowForm.GetFlow.Value;

                recalcFlow(ref compList, ref pipeList);
            }
        }

        override public void recalcFlow(ref List<Component> compList, ref List<Pipe> pipeList) {
            if (isOutAvailable != -1)
            {
                Pipe p = pipeList.Find(x => x.ID == isOutAvailable);

                if (p.MaxFlow > flow && p.CurrentFlow != flow)
                {
                    p.CurrentFlow = flow;

                    Component c = compList.Find(x => x.Id == p.EndComponentID);

                    c.recalcFlow(ref compList, ref pipeList);
                }
                else if (flow >= p.MaxFlow && p.CurrentFlow != p.MaxFlow)
                {
                    p.CurrentFlow = p.MaxFlow;

                    Component c = compList.Find(x => x.Id == p.EndComponentID);

                    c.recalcFlow(ref compList, ref pipeList);
                }
            }
        }

        override public void FlowIn(int typeOfConnection, int flow)
        {
        }

        override public int FlowOut(int typeOfConnection)
        {
            return flow;
        }

        override public String giveMeYourValuesInText()
        {
            String resume = EType+" "+id+" "+coord.X+" "+coord.Y+" "+flow+" "+isOutAvailable;
            return resume;
        }
    }
}
