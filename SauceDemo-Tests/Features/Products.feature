Feature: Products

Product information on Products and Single Product pages

Scenario Outline: Validate product information for the user on Products page
	Given The user is on the Login page
	When The user enters Username as <Username> and Password as <Password>
	Then The user clicks on Login button
	And The user views Products page
	And The user verifies Sauce Labs Backpack product information on Products page
	And The user verifies Sauce Labs Bike Light product information on Products page
	And The user verifies Sauce Labs Bolt T-Shirt product information on Products page
	And The user verifies Sauce Labs Fleece Jacket product information on Products page
	And The user verifies Sauce Labs Onesie product information on Products page
	And The user verifies Test.allTheThings() T-Shirt (Red) product information on Products page
	When The user clciks on Logout from menu options
	Then The user views Sauce Demo login page

Examples: 
	| Username                | Password     |
	| standard_user           | secret_sauce |
	| problem_user            | secret_sauce |
	| performance_glitch_user | secret_sauce |
	| error_user              | secret_sauce |
	| visual_user             | secret_sauce |

Scenario Outline: Validate product information for the user on Single Product page
	Given The user is on the Login page
	When The user enters Username as <Username> and Password as <Password>
	Then The user clicks on Login button
	And The user views Products page
	When The user clicks on Sauce Labs Backpack product image from Products page
	Then The user verifies Sauce Labs Backpack details on Product page
	When The user clicks on Back to products on Product page
	And The user clicks on Sauce Labs Bike Light product image from Products page
	Then The user verifies Sauce Labs Bike Light details on Product page
	When The user clicks on Back to products on Product page
	And The user clicks on Sauce Labs Bolt T-Shirt product image from Products page
	Then The user verifies Sauce Labs Bolt T-Shirt details on Product page
	When The user clicks on Back to products on Product page
	And The user clicks on Sauce Labs Fleece Jacket product image from Products page
	Then The user verifies Sauce Labs Fleece Jacket details on Product page
	When The user clicks on Back to products on Product page
	And The user clicks on Sauce Labs Onesie product image from Products page
	Then The user verifies Sauce Labs Onesie details on Product page
	When The user clicks on Back to products on Product page
	And The user clicks on Test.allTheThings() T-Shirt (Red) product image from Products page
	Then The user verifies Test.allTheThings() T-Shirt (Red) details on Product page
	When The user clciks on Logout from menu options
	Then The user views Sauce Demo login page

Examples: 
	| Username                | Password     |
	| standard_user           | secret_sauce |
	| problem_user            | secret_sauce |
	| performance_glitch_user | secret_sauce |
	| error_user              | secret_sauce |
	| visual_user             | secret_sauce |
