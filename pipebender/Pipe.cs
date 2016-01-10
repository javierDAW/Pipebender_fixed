using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pipebender
{
    class Pipe
    {
        private int startComponentID;
        private int endComponentID;
        //Use the enumerator TypeOfConnection in order to know the start and end position in the components (In1,In2,Out1,...)
        private int startType;
        private int endType;
        private List<Point> pointOfPipe = null;
        private int maxFlow;
        private int currentFlow;
        private int id;

        public Pipe(int StartComponentID, int EndComponentID, int startType, int endType, List<Point> pointOfPipe, int id, int maxFlow)
        {
            startComponentID = StartComponentID;
            endComponentID = EndComponentID;
            this.startType = startType;
            this.endType = endType;
            this.pointOfPipe = pointOfPipe;
            this.id = id;
            this.maxFlow = maxFlow;
        }

        public Pipe(int StartComponentID, int EndComponentID, int startType, int endType, int id, int maxFlow)
        {
            startComponentID = StartComponentID;
            endComponentID = EndComponentID;
            this.startType = startType;
            this.endType = endType;
            this.id = id;
            this.maxFlow = maxFlow;
        }

        public int StartComponentID
        {
            get
            {
                return startComponentID;
            }

            set
            {
                startComponentID = value;
            }
        }

        public int CurrentFlow
        {
            get
            {
                return currentFlow;
            }

            set
            {
                currentFlow = value;
            }
        }

        public int ID
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

        public int EndComponentID
        {
            get
            {
                return endComponentID;
            }

            set
            {
                endComponentID = value;
            }
        }

        public int StartType
        {
            get
            {
                return startType;
            }

            set
            {
                startType = value;
            }
        }

        public int EndType
        {
            get
            {
                return endType;
            }

            set
            {
                endType = value;
            }
        }

        public int MaxFlow
        {
            get
            {
                return maxFlow;
            }

            set
            {
                maxFlow = value;
            }
        }

        public List<Point> PointOfPipe
        {
            get
            {
                return pointOfPipe;
            }

            set
            {
                pointOfPipe = value;
            }
        }

        public int CalculateFlow()
        {
            return 0;
        }

        public String giveMeYourPointOfPipeValuesinText()
        {
            String points = "";
            if (pointOfPipe != null)
            {
                foreach (Point p in pointOfPipe)
                {
                    points += p.X + " " + p.Y;
                    points += Environment.NewLine;
                }
            }
            return points;
        }

        public String giveMeYourValuesInText()
        {
            String resume = id + " " + startComponentID + " " + endComponentID + " " + startType + " " + endType + " " + maxFlow + " " + currentFlow;
            return resume;
        }
    }
}
