using System;
using WFCTestLib.Log;
using WFCTestLib.Util;

namespace ReflectTools.AutoPME {
    public abstract class XObject : AutoTest {
        public XObject(String[] args) : base(args) { }
        
        ScenarioResult ObjectIsNull(Log log) {
            log.WriteLine ("erk! object is null, returning PASS - what else can I do?");
            return ScenarioResult.Pass;
        }

        protected virtual ScenarioResult ToString(TParams p) {
            object obj = (object)p.target;

            if (obj == null)
                return ObjectIsNull(p.log);

            String objText = obj.ToString();
            p.log.WriteLine(objText);
            return ScenarioResult.Pass;
        }

        protected virtual ScenarioResult GetHashCode(TParams p) {
            object obj = (object)p.target;

            if (obj == null)
                return ObjectIsNull(p.log);

            int ihashNum = obj.GetHashCode();
            p.log.WriteLine("Random=" + ihashNum.ToString());
            return ScenarioResult.Pass;
        }

        protected virtual ScenarioResult GetType(TParams p) {
            // if p.target is null it is because you cannot create an instance of this
            // type.  Pass the scenario.
            if(p.target == null)
                return ScenarioResult.Pass;

            p.log.WriteLine("Type is " + p.target.GetType().ToString());
            return ScenarioResult.Pass;
        }

        protected virtual ScenarioResult Equals(TParams p, object obj) {
            return ScenarioResult.Pass;
        }
    }
}
