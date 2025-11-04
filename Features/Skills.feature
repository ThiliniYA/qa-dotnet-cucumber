Feature: Manage Skills
  As a user, I want to add, update, and delete my skills
  So that my profile shows my skillset


   @HappyPath
   Scenario Outline: Add a skill with a specific level
    Given I am on the skills page
    When I add the skill "<SkillName>" with level "<SkillLevel>"
    Then I should see the skill "<SkillName>" with level "<SkillLevel>" in my profile

    Examples:
      | SkillName       | SkillLevel    | ExpectedResult                               |
      | HTML            | Beginner      | HTML          - Beginner is displayed        |
      | JavaScript      | Intermediate  | JavaScript - Intermediate is displayed       |
      | Web Design      | Expert        | Web Design - Expert is displayed             |


   Scenario Outline: Update an existing skill
    Given I am logged into the portal
    And I have added a skill "<OldSkillName>" with level "<OldSkillLevel>"
    When I update the skill "<OldSkillName>" to "<NewSkillName>" with level "<NewSkillLevel>"
    Then I should see the skill "<NewSkillName>" with level "<NewSkillLevel>" in my profile

   Examples: 
    | OldSkillName | OldSkillLevel | NewSkillName | NewSkillLevel | ExpectedResult                    |
    | JavaScript   | Intermediate  | Selenium     | Fluent        | New skill & skill level displayed |

  Scenario Outline: Delete a skill
   Given I am logged into the portal
   And I have added a skill "<SkillName>" with level "<SkillLevel>"
   When I delete the skill "<SkillName>"
   Then I should not see the skill "<SkillName>" in my profile

  Examples:
    | SkillName | SkillLevel   | ExpectedResult                          |
    | Selenium  | Intermediate | Can't see the skill in profile          |


   @Negative
   Scenario Outline: Attempt to add a skill with invalid or missing input
    Given I am on the skills page
    When I try to add the skill "<SkillName>" with level "<SkillLevel>"
    Then I should see an error message "<ExpectedError>"

   Examples: 
    | SkillName       | SkillLevel    | ExpectedError                          |
    |                 | Beginner      | Skill name cannot be empty             |
    | JavaScript      |               | Skill level must be selected           |
    |                 |               | Skill & skill level must be selected   |
 