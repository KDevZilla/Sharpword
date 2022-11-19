using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transitions;

namespace SharpWord.UI
{
    public class TransitionExtend : Transitions.Transition
    {
        public object Tag { get; set; }

        public TransitionExtend(ITransitionType transitionMethod) : base(transitionMethod)
        {
            this.TransitionCompletedEvent += TransitionExtend_TransitionCompletedEvent1;
        }
        private TransitionExtend _Parent;
        public TransitionExtend Parent
        {
            get { return _Parent; }
            set { _Parent = value; }
        }
        private Boolean _IsComplete = false;
        public Boolean IsComplete
        {
            get { return _IsComplete; }
        }
#pragma warning disable CS0067 // The event 'TransitionExtend.TransitionExtendAllChildComplete' is never used
        public event EventHandler TransitionExtendAllChildComplete;
#pragma warning restore CS0067 // The event 'TransitionExtend.TransitionExtendAllChildComplete' is never used

        private void TransitionExtend_TransitionCompletedEvent1(object sender, Args e)
        {
            if (Childs == null)
            {
                _IsComplete = true;

                return;
            }

            _Childs.ForEach(x => x.run());
            _Childs.ForEach(x => x.TransitionExtendAllChildComplete += X_TransitionExtendAllChildComplete);

        }

        private void X_TransitionExtendAllChildComplete(object sender, EventArgs e)
        {
            // throw new NotImplementedException();
           // TransitionExtendAllChildComplete
        }

        private int _NumberofRepeat = 0;
        public int NumberofRepeat
        {
            get { return _NumberofRepeat; }
            set { _NumberofRepeat = value; }
        }
        private int _CurrentLoop = 0;
        public int CurrentLoop
        {
            get { return _CurrentLoop; }
            private set { _CurrentLoop = value; }
        }
        private List<TransitionExtend> _Childs = null;
        public List<TransitionExtend> Childs
        {
            get { return _Childs; }
            set { _Childs = value; }
        }

        public void AddChild(TransitionExtend child)
        {
            if(_Childs ==null)
            {
                _Childs = new List<TransitionExtend>();
            }
            _Childs.Add(child);
            child.Parent = this;


        }
      
     


    }
}
