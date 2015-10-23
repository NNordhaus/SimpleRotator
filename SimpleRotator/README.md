Simple Rotator
==============

Simple rotator is an ad rotator designed to be configured, deployed, and managed as simple as possible.

It only uses the file system as its data store.

## How to use ##

1. In the App_Data folder, create a folder for each zone you wish to manage.  A zone typically refers to an area of a website that you wish to rotate ads on.  Each zone should have a single size, or sizes that are similar (such as 120x600 and 160x600).
2. Each ad you wish to show will need a text file in its respective zone.  The easiest thing to do is to copy the Template.txt file in the content folder, and then modifiy it.
3. Run SimpleRotator, go to the /Preview page to view ad codes for each zone that you can copy and paste into the web pages you wish to rotate ads on.

That's it!

A few things to note:
* Ads will only be shown between thier start and end dates.  If you want an ad to run indefinetly, just use an end date far into the future such as 2999-12-31 23:59
* The rotation number must be an integer greater than zero.  All the rotations in a zone do not have to add up to any numerber, they are not percentages.  All rotations within a zone will be added together, then a randome number within that sum will be selected.


## Any feedback is appreciated, I will consider all pull requests! ##