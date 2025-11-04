using OpenQA.Selenium;
using Reqnroll;
using NUnit.Framework;
using qa_dotnet_cucumber.Pages;

namespace qa_dotnet_cucumber.Steps
{
    [Binding]
    public class SkillsSteps
    {
        private readonly SkillsPage _skillsPage;

        public SkillsSteps(SkillsPage skillsPage)
        {
            _skillsPage = skillsPage;
        }

        [Given(@"I am logged into the portal")]
        public void GivenIAmLoggedIntoThePortal()
        {
            _skillsPage.LoginToPortal(); // you can adjust this to use your login page later
        }

        [When(@"I add a skill ""(.*)"" with level ""(.*)""")]
        public void WhenIAddASkillWithLevel(string skillName, string skillLevel)
        {
            _skillsPage.AddSkill(skillName, skillLevel);
        }

        [Then(@"I should see the skill ""(.*)"" with level ""(.*)"" in my profile")]
        public void ThenIShouldSeeTheSkillWithLevelInMyProfile(string skillName, string skillLevel)
        {
            bool isSkillVisible = _skillsPage.VerifySkillExists(skillName, skillLevel);
            Assert.That(isSkillVisible, Is.True, $"Expected skill {skillName} with level {skillLevel} not found!");
        }

        [Then(@"I should see an error message ""(.*)""")]
        public void ThenIShouldSeeAnErrorMessage(string errorMessage)
        {
            string actualError = _skillsPage.GetErrorMessage();
            Assert.That(actualError, Does.Contain(errorMessage));
        }

        [Given(@"I have added a skill ""(.*)"" with level ""(.*)""")]
        public void GivenIHaveAddedASkillWithLevel(string skillName, string skillLevel)
        {
            _skillsPage.EnsureSkillExists(skillName, skillLevel);
        }

        [When(@"I update the skill ""(.*)"" to ""(.*)"" with level ""(.*)""")]
        public void WhenIUpdateTheSkillToWithLevel(string oldSkill, string newSkill, string newLevel)
        {
            _skillsPage.UpdateSkill(oldSkill, newSkill, newLevel);
        }

        [When(@"I delete the skill ""(.*)""")]
        public void WhenIDeleteTheSkill(string skillName)
        {
            _skillsPage.DeleteSkill(skillName);
        }

        [Then(@"I should not see the skill ""(.*)"" in my profile")]
        public void ThenIShouldNotSeeTheSkillInMyProfile(string skillName)
        {
            bool isSkillVisible = _skillsPage.VerifySkillExists(skillName);
            Assert.That(isSkillVisible, Is.False, $"Skill {skillName} still appears in the profile!");
        }
    }
}
