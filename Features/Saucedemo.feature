Feature: Saucedemo

@mytag
Scenario: Add highest item to cart
	Given user is on saucedemo site
	And user login with the following creds
	| userName      | password     |
	| standard_user | secret_sauce |
	When user select the option 'second' price item and add to cart 
	Then item cart count is 1