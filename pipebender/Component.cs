using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pipebender
{
    abstract class Component
    {
        protected int id;
        protected Point coord;
        protected int eType;

        public Component(int id, Point coord, int eType)
        {
            Id = id;
            Coord = coord;
            this.eType = eType;
        }

        public Point Coord
        {
            get
            {
                return coord;
            }

            set
            {
                coord = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public int EType
        {
            get
            {
                return eType;
            }

            set
            {
                eType = value;
            }
        }

        protected bool isLeftSide(Point p, ImageList iL)
        {
            if ((p.X >= coord.X) && (p.X < coord.X + (iL.Images[EType].Width / 2)))
            {

                return true;

            }
            else
            {
                return false;
            }
        }

        protected bool isTopSide(Point p, ImageList iL)
        {
            if ((p.Y >= coord.Y) && (p.Y < coord.Y + (iL.Images[EType].Height / 2)))
            {

                return true;
            }
            else
            {
                return false;
            }
        }


        public abstract int isComponentConnectionAvailable(Point p, ImageList iL);

        public abstract int whatKindOfCoennectionIs(Point p, ImageList iL);

        public abstract void invalidateConnectionValidateConnection(int typeOfConnection, int op);

        public abstract void FlowIn(int typeOfConnection, int flow);

        public abstract int FlowOut(int typeOfConnection);

        public abstract void configureValues(ref List<Component> compList, ref List<Pipe> pipeList);

        public abstract void recalcFlow(ref List<Component> compList, ref List<Pipe> pipeList);

        public abstract String giveMeYourValuesInText();
    }
}
