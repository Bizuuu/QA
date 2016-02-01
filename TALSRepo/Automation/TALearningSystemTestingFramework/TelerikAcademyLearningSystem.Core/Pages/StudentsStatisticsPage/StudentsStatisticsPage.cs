﻿namespace TelerikAcademyLearningSystem.Core.Pages.StudentsStatisticsPage
{
    using System;
    using Base;
    using TelerikAcademyLearningSystem.Core.Constants;

    public partial class StudentsStatisticsPage : BasePage<StudentsStatisticsPage>
    {
        public override void Navigate()
        {
            this.Browser.NavigateTo(UrlLink.StudentsStatisticsPage);
        }

        public void SelectAllCourses()
        {
            this.SelectCourse("Всички курсове");
        }

        public void SelectFixedCourse(string courseName)
        {
            this.SelectCourse(courseName);
        }

        public void SelectFixedCourseInSomeForm(string courseName, string form)
        {
            switch (form)
            {
                case "Присъствено":
                    this.CourseFilter.Wait.ForVisible();
                    this.CourseFilter.ScrollToVisible();
                    this.CourseFilter.MouseClick();
                    this.Browser.Desktop.KeyBoard.TypeText(courseName);
                    this.LiveRadioButton.MouseClick();
                    this.Browser.WaitForAjax(10000);
                    this.Browser.RefreshDomTree();
                    break;

                case "Онлайн":
                    this.CourseFilter.Wait.ForVisible();
                    this.CourseFilter.ScrollToVisible();
                    this.CourseFilter.MouseClick();
                    this.Browser.Desktop.KeyBoard.TypeText(courseName);
                    this.OnlineRadioButton.MouseClick();
                    this.Browser.WaitForAjax(10000);
                    this.Browser.RefreshDomTree();
                    break;

                case "Присъствено и Онлайн":
                    this.SelectCourse(courseName);
                    break;

                default:
                    throw new ArgumentException("No such form of education. Select one from Присъствено и Онлайн, Присъствено, Онлайн");
            }
        }

        private void SelectCourse(string courseName)
        {
            this.CourseFilter.Wait.ForVisible();
            this.CourseFilter.ScrollToVisible();
            this.CourseFilter.MouseClick();
            this.Browser.Desktop.KeyBoard.TypeText(courseName);
            this.LiveAndOnlineRadioButton.MouseClick();
            this.Browser.WaitForAjax(10000);
            this.Browser.RefreshDomTree();
        }
    }
}