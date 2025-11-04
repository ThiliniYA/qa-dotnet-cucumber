Feature: Login Functionality
  As a user, I want to log in to the application to access restricted content.

  @HappyPath
  Scenario Outline: Perform login with valid credentials
    Given I am on the login page
    When I enter username "<Username>" and password "<Password>"
    Then I should see "<ExpectedResult>"

    Examples:
      | Username   | Password             | ExpectedResult                        |
      | tomsmith   | SuperSecretPassword! | You logged into a secure area!        |

  @Negative
  Scenario Outline: Fail login with invalid credentials
    Given I am on the login page
    When I enter username "<Username>" and password "<Password>"
    Then I should see "<ExpectedResult>"

    Examples:
      | Username   | Password             | ExpectedResult                |
      | invalid    | SuperSecretPassword! | Your username is invalid!     |
      | tomsmith   | wrongpass            | Your password is invalid!     |
      |            |                      | Your username is required!    |
     

  @Validation
  Scenario Outline: Fail login with short password
    Given I am on the login page
    When I enter username "<Username>" and password "<Password>"
    Then I should see "<ExpectedResult>"

    Examples:
      | Username   | Password | ExpectedResult                           |
      | tomsmith   | abc      | Password must be at least 6 characters   |

 @Destructive
 Scenario: Fail login with very long username and password
  Given I am on the login page
  When I enter username "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" and password "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb"
  Then I should see "Your username or password is invalid!"

 @Destructive
 Scenario: Fail login with special characters in username and password
  Given I am on the login page
  When I enter username "!@#$%^&*()_+|~=`{}[]:\";'<>?,./" and password "!@#$%^&*()_+|~=`{}[]:\";'<>?,./"
  Then I should see "Your username or password is invalid!"


 


 