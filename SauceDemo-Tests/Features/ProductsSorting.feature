Feature: ProductsSorting

Products Sorting functionality on All Products page

Scenario Outline: Validate product sorting functionality for the user on Products page
	Given The user is on the Login page
	When The user enters Username as <Username> and Password as <Password>
	Then The user clicks on Login button
		And The user views Products page
		And The user verify default sorting order on the Products page
	When The user selects <SortOrder2> from the filter dropdown on the Products page
	Then The user verify <SortOrder2> sorting order on the Products page
	When The user selects <SortOrder3> from the filter dropdown on the Products page
	Then The user verify <SortOrder3> sorting order on the Products page
	When The user selects <SortOrder4> from the filter dropdown on the Products page
	Then The user verify <SortOrder4> sorting order on the Products page
	When The user selects <SortOrder1> from the filter dropdown on the Products page
	Then The user verify <SortOrder1> sorting order on the Products page
	When The user clciks on Logout from menu options
	Then The user views Sauce Demo login page

	Examples: 
	| Username                | Password     | SortOrder1    | SortOrder2    | SortOrder3          | SortOrder4          |
	| standard_user           | secret_sauce | Name (A to Z) | Name (Z to A) | Price (low to high) | Price (high to low) |
	| problem_user            | secret_sauce | Name (A to Z) | Name (Z to A) | Price (low to high) | Price (high to low) |
	| performance_glitch_user | secret_sauce | Name (A to Z) | Name (Z to A) | Price (low to high) | Price (high to low) |
	| error_user              | secret_sauce | Name (A to Z) | Name (Z to A) | Price (low to high) | Price (high to low) |
	| visual_user             | secret_sauce | Name (A to Z) | Name (Z to A) | Price (low to high) | Price (high to low) |