using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pipebender
{
    class Normal : Splitter
    {
        public Normal(int id, Point coord, int splitterType, int eType) : base(id, coord, splitterType, eType)
        {
            Id = id;
            Coord = coord;
            this.splitterType = splitterType;
        }

        override public void configureValues(ref List<Component> compList, ref List<Pipe> pipeList)
        {
            MessageBox.Show("Nothing can be configured here");
        }

        override public void recalcFlow(ref List<Component> compList, ref List<Pipe> pipeList) {
            Pipe p1 = pipeList.Find(x => x.EndComponentID == id);

            flowIn = p1.CurrentFlow;
            flowOut1 = flowIn / 2;
            flowOut2 = flowIn / 2;

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
        }

        override public int FlowOut(int typeOfConnection)
        {
            if (typeOfConnection == (int)TypeOfConnection.TopOutput)
            {
                flowOut1 = flowIn / 2;
                return flowOut1;
            }
            else
            {
                flowOut2 = flowIn / 2;
                return flowOut2;
            }
        }

        override public String giveMeYourValuesInText()
        {
            String resume = EType + " " + id + " " + coord.X + " " + coord.Y + " " +splitterType+ " " + isInAvailable + " " + isOut1Available + " " + isOut2Available + " " + flowIn + " " + flowOut1 + " " + flowOut2;
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
                Component c = compList.Find(x => x.Id == p1.StartComponentID);

                pipeList.Remove(p1);

                c.removeFlowItems(ref compList, ref pipeList);
            }

            if (p2 != null)
            {
                Component c = compList.Find(x => x.Id == p2.EndComponentID);

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
