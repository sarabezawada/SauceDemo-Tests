Feature: Login
	Successfull and unsuccessful login attempts into Sauce Demo application

Scenario Outline: Validate successful user login into Sauce Demo application
	Given The user is on the Login page
	When The user enters Username as <Username> and Password as <Password>
	Then The user clicks on Login button
	And The user views Products page
	When The user clciks on Logout from menu options
	Then The user views Sauce Demo login page

Examples: 
	| Username                | Password     |
	| standard_user           | secret_sauce |
	| problem_user            | secret_sauce |
	| performance_glitch_user | secret_sauce |
	| error_user              | secret_sauce |
	| visual_user             | secret_sauce |



Scenario Outline: Validate unsuccessful user login into Sauce Demo application
	Given The user is on the Login page
	When The user enters Username as <Username> and Password as <Password>
	Then The user clicks on Login button
	And The user views Error message <ErrorMessage> on the Login page
	When The user clicks on Close icon in the error message on the Login page
	Then The user view Login page without any errors

Examples: 
	| Username        | Password     | ErrorMessage                                                              |
	| Blank           | Blank        | Epic sadface: Username is required                                        |
	| Blank           | secret_sauce | Epic sadface: Username is required                                        |
	| Test            | Blank        | Epic sadface: Password is required                                        |
	| Test            | Test         | Epic sadface: Username and password do not match any user in this service |
	| locked_out_user | secret_sauce | Epic sadface: Sorry, this user has been locked out.                       |

