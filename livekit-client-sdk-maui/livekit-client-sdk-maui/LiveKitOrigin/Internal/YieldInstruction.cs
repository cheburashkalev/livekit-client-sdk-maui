

namespace LiveKit
{
    public class YieldInstruction
    {
        public bool IsDone { protected set; get; }
        public bool IsError { protected set; get; }

        public bool keepWaiting => !IsDone;
    }
}
