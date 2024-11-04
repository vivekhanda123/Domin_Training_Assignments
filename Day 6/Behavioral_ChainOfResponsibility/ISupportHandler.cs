using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioral_ChainOfResponsibility
{
    public interface ISupportHandler
    {
        void HandleRequest(string issue);
        ISupportHandler SetNext(ISupportHandler nextHandler);
    }
    public abstract class SupportHandler : ISupportHandler
    {
        private ISupportHandler _nextHandler;
        public ISupportHandler SetNext(ISupportHandler nextHandler)
        {
            _nextHandler = nextHandler;
            return nextHandler;
        }
        public virtual void HandleRequest(string issue)
        {
            if(_nextHandler!= null)
            {
                _nextHandler.HandleRequest(issue);
            }
        }
    }
    public class LevelOneSupport : SupportHandler
    {
        public override void HandleRequest(string issue)
        {
            if (issue == "Simple issue")
                Console.WriteLine("Level one support handle simple issue");
            else
                base.HandleRequest(issue);
        }
    }
    public class LevelTwoSupport : SupportHandler
    {
        public override void HandleRequest(string issue)
        {
            if (issue == "Complex issue")
                Console.WriteLine("Level two support handle simple issue");
            else
                base.HandleRequest(issue);
        }
    }
    public class LevelThreeSupport : SupportHandler
    {
        public override void HandleRequest(string issue)
        {
            if (issue == "Very complex issue")
                Console.WriteLine("Level three support handle simple issue");
            else
                base.HandleRequest(issue);
        }
    }
}
