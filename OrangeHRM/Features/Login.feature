Feature: Login

A short summary of the feature

@tag1
Scenario: User can sign in succesfully
	Given OrangeHrm is loaded succesfully
	When Inserts the username and password appropriately
	And User clicks on Login
	Then User is signed in succesfully
