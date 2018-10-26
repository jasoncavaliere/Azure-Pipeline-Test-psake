using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PipelineTest.Tests
{
    public class Class1
    {

        [Fact(Skip = "Ignore for demo")]
        public void should_fail()
        {
            Assert.True(false);
        }

        
        [Fact]
        public void should_succeed()
        {
            Assert.True(true);
        }

    }
}
