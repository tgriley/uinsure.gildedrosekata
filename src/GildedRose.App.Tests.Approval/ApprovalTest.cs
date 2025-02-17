﻿using GildedRoseKata;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

namespace GildedRose.Tests.Acceptance
{
    public class ApprovalTest
    {
        [Fact]
        public Task ThirtyDays()
        {
            var fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            Console.SetIn(new StringReader("a\n"));

            Program.Main();
            var output = fakeoutput.ToString();

            return Verifier.Verify(output);
        }
    }
}