<%@ Page Title="" Language="C#" MasterPageFile="~/ui/mp/MasterPage.master" AutoEventWireup="true" CodeFile="support.aspx.cs" Inherits="support" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
    .limit
    {
        width: 70%;   
    }
</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1>Frequently Asked Questions</h1>
<br />
<ul>
    <li style="float:none; width:auto;"><a href="#" style="color:Black;">What is LimitBreaker?</a></li>
    <li style="float:none; width:auto;"><a href="#" style="color:Black;">How do I get started?</a></li>
    <li style="float:none; width:auto;"><a href="#" style="color:Black;">What are experience points and levels?</a></li>
    <li style="float:none; width:auto;"><a href="#" style="color:Black;">What are the leaderboards?</a></li>
    <li style="float:none; width:auto;"><a href="#" style="color:Black;">Can I opt out of the leaderboards?</a></li>
    <li style="float:none; width:auto;"><a href="#" style="color:Black;">What can I do with my profile?</a></li>
    <li style="float:none; width:auto;"><a href="#" style="color:Black;">What is a routine, and how do I create one?</a></li>
    <li style="float:none; width:auto;"><a href="#" style="color:Black;">What is logging an exercise, and how do I do it?</a></li>
    <li style="float:none; width:auto;"><a href="#" style="color:Black;">How do I schedule exercises/routines?</a></li>
    <li style="float:none; width:auto;"><a href="#" style="color:Black;">I made a mistake on the calender, how do I fix it?</a></li>
    <li style="float:none; width:auto;"><a href="#" style="color:Black;">What are exercise goals and how do I make them?</a></li>
    <li style="float:none; width:auto;"><a href="#" style="color:Black;">How do I achieve my exercise goals, do I have to manually do it?</a></li>
    
</ul>

<br />

<h3 id="">What is LimitBreaker?</h3>
<p class="limit">LimitBreaker is an exercise logging application that incorporates the experience rewards system from games. 
                 In addition to logging exercises, LimitBreaker is capable of scheduling exercises, creating routines, setting goals, and seeing whos on top of the leaderboards. 
                 More features to come in the future!</p>
<a href="#" style="color:Black; font-size: 0.67em;">Top of Page</a>
<br />

<h3 id="">How do I get started?</h3>
<p class="limit">Create an account by clicking on any of the tabs on the left side, you ill be redirected to the create account page.
                 Enter all of your information in the given text boxes.  All fields are reuired.  You will be sent and email to verify your account.
                 The functionality of these tabs will become active once you have created an account, verified your email and log in.</p>
<a href="#" style="color:Black; font-size: 0.67em;">Top of Page</a>
<br />

<h3 id="">What are experience points and levels?</h3>
<p class="limit">Experience points are a system which allow you to see your progress for working out.
                 Every time you log an exercise or routine, you will be awarded experience points. The amount of experiecne rewarded varies for each exercise, and how much you did for that exercise. 
                 Once you have collected enough experience points, you will level up!
                 Each level progressively requires more and more experience to reac hthe next. 
                 This information can be found in your profile page, or on our leaderboards so you can see where you rank within all LimitBreakers.</p>
<a href="#" style="color:Black; font-size: 0.67em;">Top of Page</a>
<br />

<h3 id="">What are the leaderboards?</h3>
<p class="limit">The leaderboards show the ranking of who has the most experience/logged exercises/achieved goals.
                 They can be viewed while logged off or on.  While logged on you will see your ranking at all times.
                 The leaderboards are a way to promote healthy competition between LimitBreakers.
                 If you get into the top 3 of any of the categories, you will be awarded a medal on your orfile, so get exercising!</p>
<a href="#" style="color:Black; font-size: 0.67em;">Top of Page</a>
<br />

<h3 id="">Can I opt out of the leaderboards?</h3>
<p class="limit">No you cannot opt out of the leaderboards. No private information is displayed in the leaderboards, 
                 and no one will be able to contact you through the information found in the leaderboards.
                 For more information on our privacy policy, see it <asp:HyperLink ID="tosLink" runat="server" NavigateUrl="~/termsOfService.aspx" Target="_blank">here</asp:HyperLink></p>
<a href="#" style="color:Black; font-size: 0.67em;">Top of Page</a>
<br />

<h3 id="">What can I do with my profile?</h3>
<p class="limit">Your user profile shows you all the information about you. You can update your weight, height, email, or change your password.
                 You may only update your profile once a day however. 
                 When you update your weight it is added to the chart which you can use to view your weight gain/loss over the course of time you have been a LimitBreaker. 
                 Hovering over the chart will show you the date and weight of each plot point, 
                 and you can zoom in further or select and smaller range of data with the select tool, or the scrolling bar at the bottom.</p>
<a href="#" style="color:Black; font-size: 0.67em;">Top of Page</a>
<br />

<h3 id="">What is a routine, and how do I create one?</h3>
<p class="limit">A routine is a collection of exercises that you would want to do in unison. The "User Routines" page has 4 options, click on the "Creatine Routine" button to  get started with them.
                 Select a muscle group and then select exercises from the list to add the routine.  Give it a name and you've made a routine!
                 You can modify the contents or name of the routine by choosing the "Modify Routine" button on the routine front page. 
                 Select a routine you've made, and the process is the same as creating. All steps are optional when modifying.</p>
<a href="#" style="color:Black; font-size: 0.67em;">Top of Page</a>
<br />

<h3 id="3">What is logging an exercise, and how do I do it?</h3>
<p class="limit">Logging an exercise is a way to keep track of which exercises you have done, and the various atributes of the exercises (weight, reps etc). 
                 Logging an exercise will reward you experience depedning on the exercise itself, and the various attributes within the exercise. 
                 On the "Log Exercises" page you will be able to search for any exercise within the system.
                 When you've found the exercise that you have done, enter the values for each attribute and add a set.
                 When you have not logged a set for the exercise within the past hour, it will create a new logg for it, otherwise it will add the set to the previous log.
                 You can view each log for each exercise that you have done by selecting them at the bottom.
                 <br />
                 These same steps can be done for the exercises within a routine.  Rather than doing them on the "Log Exercises" page, 
                 choose the "Create Logs" option on the "User Routines" page, then select a routine.  You can log the data for the exercises there.</p>
<a href="#" style="color:Black; font-size: 0.67em;">Top of Page</a>
<br />

<h3 id="">How do I schedule exercises/routines?</h3>
<p class="limit">You can find a personal calender on the "Workout Schedule" page. With this you can schedule routines and exercises to do at a later date.
                 To schedule a routine/exercise, either choose the "Add Item" option at the top, or select a day and select to "Add an item for this day".
                 You can then choose between adding a routine or exercise, which then brings you to a list of either to select from. 
                 Follow the instructins to choose the start time and date, then select "Schedule Routine" or "Schedule Exercise".
                 You have now successfully scheduled an item!</p>
<a href="#" style="color:Black; font-size: 0.67em;">Top of Page</a>
<br />

<h3 id="">I made a mistake on the calender, how do I fix it?</h3>
<p class="limit">To either delete scheduled items or modify them, either click on a date or choose the "Remove or Modify Item" option at the top of the page.
                 You can then select a scheduled item for that day, and modify its contents or remove it from the calender.</p>
<a href="#" style="color:Black; font-size: 0.67em;">Top of Page</a>
<br />

<h3 id="">What are exercise goals and how do I make them?</h3>
<p class="limit">Exercise goals are achievements that you set for yourself, for a particular exercise. To create them, 
                 choose the "Add an Exercise Goal" option at the top of the "Exercise Goals" page. 
                 You can then choose an exercise you would like to set a goal for, adjust the values for the attributes that you would like to reach, and save it. 
                 You cannot have more than one active goal for each exercise.
                 Your goal is now available to view from the "View Exercise Goals" option at the top of the page. 
                 This page also allows you to modify or delete your current goals.</p>
<a href="#" style="color:Black; font-size: 0.67em;">Top of Page</a>
<br />

<h3 id="">How do I achieve my exercise goals, do I have to manually do it?</h3>
<p class="limit">When you log an exercise, the system will automatically check if you have reached the values for your goals, and se them to an "achieved" status if you have met them.
                 Your achieved goals are viewable under the "View Exercise Goals" option on the "Exercise Goals" page.
                 Select the achieved option, this will display your achieved goals. </p>
<a href="#" style="color:Black; font-size: 0.67em;">Top of Page</a>
<br />

</asp:Content>

