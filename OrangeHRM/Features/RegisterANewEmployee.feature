Feature: RegisterANewEmployee

A short summary of the feature

@tag1
Scenario: A user can register a new employee
	Given OrangeHrm is loaded succesfully
	When Inserts the username and password appropriately
	And User clicks on Login
	And User navigate to PIM page and click add employee
	And User fills Employee details 
	Then the employee is added succesfully
