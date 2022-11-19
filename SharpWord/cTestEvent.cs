using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpWord
{
    public class cTestEvent
    {
        //public delegate void MyEventHandler(string foo);
        public event EventHandlerv2 MyEvent;
        public delegate void EventHandlerv2(object sender, EventArgs e);

        private int _MyValue = 0;
        public int MyValue{
            get { return _MyValue; }
            set { _MyValue = value; }
            }
        public cTestEvent ()
        {
            this.MyEvent += CTestEvent_MyEvent;
        }

        private void CTestEvent_MyEvent(object sender, EventArgs e)
        {
#pragma warning disable CS0219 // The variable 'str' is assigned but its value is never used
            String str = "C_Self";
#pragma warning restore CS0219 // The variable 'str' is assigned but its value is never used
        }

        public void Call()
        {
            if(MyEvent !=null)
            {
                MyEvent(this, new EventArgs());
            }
        }
    }
    public class cUsingEvent
    {
        private cTestEvent c = new cTestEvent();
        public void Test()
        {
            c.Call();
        }
        public cUsingEvent()
        {
            c.MyEvent += C_MyEvent1;
        }

        private void C_MyEvent1(object sender, EventArgs e)
        {
            //    throw new NotImplementedException();
#pragma warning disable CS0219 // The variable 'str' is assigned but its value is never used
            String str = "C_MyEvent1";
#pragma warning restore CS0219 // The variable 'str' is assigned but its value is never used
        }

        private void C_MyEvent(object sender, EventArgs e)
        {
            //tring strHell = "cUsingEvent";
            //throw new NotImplementedException();

        }
    }
}
