using NUnit.Framework;

namespace ValidBrackets;

[TestFixture]
public class ProgramTest
{
    private Program program = new Program();

    [Test]
    [TestCase("[{()}]")]
    [TestCase("[]")]
    [TestCase("(({}))")]
    public async Task IsCorrect_ShouldReturnTrue_ForValidInput(string input)
    {
        var result = program.IsCorrect(input);

        Assert.IsTrue(result);
    }

    [Test]
    [TestCase("")]
    [TestCase(null)]
    [TestCase("[}")]
    [TestCase("[[")]
    [TestCase("[(])")]
    public async Task IsCorrect_ShouldReturnFalse_ForInvalidInput(string input)
    {
        var result = program.IsCorrect(input);

        Assert.IsFalse(result);
    }
}
