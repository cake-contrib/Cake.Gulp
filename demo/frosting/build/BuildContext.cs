using Cake.Core;
using Cake.Frosting;

namespace Build
{
    public class BuildContext : FrostingContext
    {
        public BuildContext(ICakeContext context)
            : base(context)
        {
        }
    }
}
