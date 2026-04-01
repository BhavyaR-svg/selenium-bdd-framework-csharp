Feature: Login

@Regression @Smoke
Scenario: Successful login
    Given User is on login page
    When User enters valid credentials
    And Clicks login button
    Then User should be logged in successfully

    #Data Driven BDD
    Scenario Outline: Login test

    Given User is on login page
    When User enters credentials "<username>" and "<password>"
    Then User should be logged in successfully

Examples:
| username        | password  |
| testuser_1      | Test@123  |
| wrong_user      | wrong123  |

    #Data from json file Driven BDD
Scenario: Login test Json

    Given User is on login page
    When User logs in with valid data from json
    Then User should be logged in successfully