using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pipebender
{
    class ModelClass
    {
        int id, x, y, type,idPipe;
        String s;
        public void openFile(ComponentTable ct, StreamReader sr)
        {
            String[] tokens;
            //first process all components
            s = sr.ReadLine(); s = sr.ReadLine();
            while (s != "pipes")
            {
                tokens = s.Split();

                type = Convert.ToInt32(tokens[0]);

                switch (type)
                {
                    case (int)EnumTypes.Pump:
                        createPump(ct, tokens);
                        break;
                    case (int)EnumTypes.Sink:
                        createSink(ct, tokens);
                        break;
                    case (int)EnumTypes.Merger:
                        createMerger(ct, tokens);
                        break;
                    case (int)EnumTypes.Normal:
                        createNormal(ct, tokens);
                        break;
                    case (int)EnumTypes.Regulable:
                        createRegulable(ct, tokens);
                        break;
                }
                s = sr.ReadLine();
            }

            s = sr.ReadLine();
            while (s != "end")
            {
                tokens = s.Split();
                createPipe(ct, tokens,sr);
                //s = sr.ReadLine();

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

        public int IdPipe
        {
            get
            {
                return idPipe;
            }

            set
            {
                idPipe = value;
            }
        }



        public void createPipe(ComponentTable ct, String[] tokens,StreamReader sr)
        {
            
            idPipe = Convert.ToInt32(tokens[0]);
            int startComponentID = Convert.ToInt32(tokens[1]);
            int endComponentID = Convert.ToInt32(tokens[2]);
            int startType = Convert.ToInt32(tokens[3]);
            int endType = Convert.ToInt32(tokens[4]);
            int maxFlow = Convert.ToInt32(tokens[5]);
            int currentFlow = Convert.ToInt32(tokens[6]);

            Pipe pipe = new Pipe(startComponentID,endComponentID,startType, endType, id, maxFlow);
            pipe.CurrentFlow = currentFlow;

            //Let´s check if there are intermediate points in the pipe
            String[] PipesToken;
            s = sr.ReadLine();
            
            if (s == "startpoints")
            {
                s = sr.ReadLine();
                List<Point> pipesCoordAux = new List<Point>();

                while (s != "endpoints")
                {
                    PipesToken = s.Split();
                    int x = Convert.ToInt32(PipesToken[0]);
                    int y = Convert.ToInt32(PipesToken[1]);
                    Point point = new Point(x, y);
                    pipesCoordAux.Add(point);
                    s = sr.ReadLine();

                }
                pipe.PointOfPipe = pipesCoordAux;
                s = sr.ReadLine();
            }
            
            ct.PipeList.Add(pipe);
            
        }

        public void saveFile(ComponentTable ct, StreamWriter sw)
        {
            sw.WriteLine("components");
            foreach(Component c in ct.CompList)
            {
                sw.WriteLine(c.giveMeYourValuesInText());
            }
            sw.WriteLine("pipes");
            foreach (Pipe p in ct.PipeList)
            {
                sw.WriteLine(p.giveMeYourValuesInText());
                if(p.giveMeYourPointOfPipeValuesinText() != "")
                {
                    sw.WriteLine("startpoints");
                    sw.Write(p.giveMeYourPointOfPipeValuesinText());
                    sw.WriteLine("endpoints");
                }
            }
            sw.WriteLine("end");
        }
        private void createPump(ComponentTable ct, String[] tokens)
        {
            id = Convert.ToInt32(tokens[1]);
            x = Convert.ToInt32(tokens[2]);
            y = Convert.ToInt32(tokens[3]);
            int f = Convert.ToInt32(tokens[4]);
            int isOutAvail = Convert.ToInt32(tokens[5]);
            Point p = new Point(x, y);
            Pump pump = new Pump(id, p, type);
            ct.CompList.Add(pump);
            pump.Flow = f;
            pump.IsOutAvailable = isOutAvail;
        }

        private void createMerger(ComponentTable ct, String[] tokens)
        {
            id = Convert.ToInt32(tokens[1]);
            x = Convert.ToInt32(tokens[2]);
            y = Convert.ToInt32(tokens[3]);
            int isIn1Avail = Convert.ToInt32(tokens[4]);
            int isIn2Avail = Convert.ToInt32(tokens[5]);
            int isOutAvail = Convert.ToInt32(tokens[6]);
            int in1Flow = Convert.ToInt32(tokens[7]);
            int in2Flow = Convert.ToInt32(tokens[8]);
            int outFlow = Convert.ToInt32(tokens[9]);
            Point p = new Point(x, y);
            Merger merger = new Merger(id, p, type);
            ct.CompList.Add(merger);
            merger.IsIn1Available = isIn1Avail;
            merger.IsIn2Available = isIn2Avail;
            merger.IsOutAvailable = isOutAvail;
            merger.FlowIn1 = in1Flow;
            merger.FlowIn2 = in2Flow;
            merger.GetFlowOut = outFlow;
        }

        private void createNormal(ComponentTable ct, String[] tokens)
        {
            id = Convert.ToInt32(tokens[1]);
            x = Convert.ToInt32(tokens[2]);
            y = Convert.ToInt32(tokens[3]);
            int splitterType = Convert.ToInt32(tokens[4]);
            int isInAvail = Convert.ToInt32(tokens[5]);
            int isOut1Avail = Convert.ToInt32(tokens[6]);
            int isOut2Avail = Convert.ToInt32(tokens[7]);
            int inFlow = Convert.ToInt32(tokens[8]);
            int out1Flow = Convert.ToInt32(tokens[9]);
            int out2Flow = Convert.ToInt32(tokens[10]);
            Point p = new Point(x, y);
            Normal normal = new Normal(id, p, splitterType, type);
            ct.CompList.Add(normal);
            normal.IsInAvailable = isInAvail;
            normal.IsOut1Available = isOut1Avail;
            normal.IsOut2Available = isOut2Avail;
            normal.GetFlowIn = inFlow;
            normal.GetFlowOut1 = out1Flow;
            normal.GetFlowOut2 = out2Flow;
        }

        private void createRegulable(ComponentTable ct, String[] tokens)
        {
            id = Convert.ToInt32(tokens[1]);
            x = Convert.ToInt32(tokens[2]);
            y = Convert.ToInt32(tokens[3]);
            int splitterType = Convert.ToInt32(tokens[4]);
            int isInAvail = Convert.ToInt32(tokens[5]);
            int isOut1Avail = Convert.ToInt32(tokens[6]);
            int isOut2Avail = Convert.ToInt32(tokens[7]);
            int inFlow = Convert.ToInt32(tokens[8]);
            int out1Flow = Convert.ToInt32(tokens[9]);
            int out2Flow = Convert.ToInt32(tokens[10]);
            int percentage = Convert.ToInt32(tokens[11]);
            Point p = new Point(x, y);
            Regulable regulable = new Regulable(id, p, splitterType,percentage, type);
            ct.CompList.Add(regulable);
            regulable.IsInAvailable = isInAvail;
            regulable.IsOut1Available = isOut1Avail;
            regulable.IsOut2Available = isOut2Avail;
            regulable.GetFlowIn = inFlow;
            regulable.GetFlowOut1 = out1Flow;
            regulable.GetFlowOut2 = out2Flow;
            regulable.GetFlowOut2 = out2Flow;
            
        }


        private void createSink(ComponentTable ct, String[] tokens)
        {
            id = Convert.ToInt32(tokens[1]);
            x = Convert.ToInt32(tokens[2]);
            y = Convert.ToInt32(tokens[3]);
            int f = Convert.ToInt32(tokens[4]);
            int isInAvail = Convert.ToInt32(tokens[5]);
            Point p = new Point(x, y);
            Sink sink = new Sink(id, p,f, type);
            ct.CompList.Add(sink);
            sink.IsInAvailable = isInAvail;
        }
    }
}
