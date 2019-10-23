﻿using System;

namespace TEFL_App.Models
{
    public class TEFLProfile
    {
        #region Public Properties

        public int? CertificateID { get; set; }
        public int Company_ID { get; set; }
        public DateTime? CompletionDate { get; set; }
        public int ExamAttempts { get; set; }
        public string ExamScores { get; set; }
        public int ID { get; set; }
        public string LessonPlanPath { get; set; }
        public string Mod1QuizScores { get; set; }
        public string Mod2QuizScores { get; set; }
        public string Mod3QuizScores { get; set; }
        public string Mod4QuizScores { get; set; }
        public string ModulesComplete { get; set; }
        public string Name { get; set; }
        public int Paid { get; set; }
        public int PaidAmount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime RegistrationDate { get; set; }

        #endregion Public Properties

        #region Local Data

        public string AppPassword { get; set; } = "";
        public string AppUsername { get; set; } = "";
        public DateTime? LastLogin { get; set; }
        public bool LessonPlanSubmitted { get; set; } = false;

        #endregion Local Data
    }
}