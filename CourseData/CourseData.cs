using System.Collections.Generic;

namespace TEFL_App.CourseData
{
    public static class CourseData
    {
        #region Public Fields

        public static List<ChapterTitleData> Chapters = new List<ChapterTitleData>()
        {
            ///Mod1 Part1
            new ChapterTitleData("1.1.0", "Part 1 - Introduction", null),
            new ChapterTitleData("1.1.1", "A brief story of and foreword by the founders", "mod1part1sect1"),
            new ChapterTitleData("1.1.2", "The mission of the North American TEFL Academy", "mod1part1sect2"),
            new ChapterTitleData("1.1.3", "Course technology requirements", "mod1part1sect3"),
            new ChapterTitleData("1.1.4", "Course duration and general time expectations", "mod1part1sect4"),
            new ChapterTitleData("1.1.5", "How to begin and progress through the course", "mod1part1sect5"),
            new ChapterTitleData("1.1.6", "Non-graded module self-assessment tests", "mod1part1sect6"),
            new ChapterTitleData("1.1.7", "Graded exam", "mod1part1sect7"),
            new ChapterTitleData("1.1.8", "Lesson plan assignment", "mod1part1sect8"),
            new ChapterTitleData("1.1.9", "How to pass the course", "mod1part1sect9"),
            new ChapterTitleData("1.1.10", "Can the course be retaken if initially failed?", "mod1part1sect10"),
            new ChapterTitleData("1.1.11", "How to receive the certificate", "mod1part1sect11"),

            ///Mod1 Part2
            new ChapterTitleData("1.2.0", "Part 2 - Language Teaching Theory & Method", null),
            new ChapterTitleData("1.2.1", "Methodology Overview", "mod1part2sect1"),
            new ChapterTitleData("1.2.2", "Grammar-Translation", "mod1part2sect2"),
            new ChapterTitleData("1.2.2a", "Summary of the Grammar-Translation Methodology", "mod1part2sect3"),
            new ChapterTitleData("1.2.3", "The Direct Method", "mod1part2sect4"),
            new ChapterTitleData("1.2.3a", "Summary of the Direct Method", "mod1part2sect5"),
            new ChapterTitleData("1.2.4", "The Audiolingual Method", "mod1part2sect6"),
            new ChapterTitleData("1.2.4a", "Summary of the Audiolingual Method", "mod1part2sect7"),
            new ChapterTitleData("1.2.5", "Suggestopedia", "mod1part2sect8"),
            new ChapterTitleData("1.2.5a", "Summary of Suggestopedia", "mod1part2sect9"),
            new ChapterTitleData("1.2.6", "Total Physical Response (TPR)", "mod1part2sect10"),
            new ChapterTitleData("1.2.6a", "Summary of Total Physical Response (TPR)", "mod1part2sect11"),
            new ChapterTitleData("1.2.7", "Communicative Language Teaching", "mod1part2sect12"),
            new ChapterTitleData("1.2.8", "Multiple Intelligences", "mod1part2sect13"),
            new ChapterTitleData("1.2.9", "Conclusion", "mod1part2sect14"),

            //Mod1 Part 3
            new ChapterTitleData("1.3.0", "Part 3 - Grammar for Teachers", null),
            new ChapterTitleData("1.3.1", "Grammar Overview", "mod1part3sect1"),
            new ChapterTitleData("1.3.2", "Parts of Speech", "mod1part3sect2"),
            new ChapterTitleData("1.3.3", "Tenses", "mod1part3sect3"),

            //Mod 1 Quiz
            new ChapterTitleData("1.4.0", "Module 1 Quiz", null),

            //Mod 2 Part 1
            new ChapterTitleData("2.1.0", "Part 1 - Student Age and Language Levels", null),
            new ChapterTitleData("2.1.1", "Overview", "mod2part1sect1"),
            new ChapterTitleData("2.1.2", "The Significance of Student Age", "mod2part1sect2"),
            new ChapterTitleData("2.1.3", "Teaching Children & Early Learners", "mod2part1sect3"),
            new ChapterTitleData("2.1.4", "Teaching Young Adults", "mod2part1sect4"),
            new ChapterTitleData("2.1.5", "Teaching Adults", "mod2part1sect5"),
            new ChapterTitleData("2.1.5a", "Treating Adults Like Adults", "mod2part1sect6"),
            new ChapterTitleData("2.1.6", "The Common European Framework of Reference (CEFR)", "mod2part1sect7"),
            new ChapterTitleData("2.1.7", "CEFR: Common Reference Levels (CRLs)", "mod2part1sect8"),
            new ChapterTitleData("2.1.7a", "Global Scale", "mod2part1sect9"),
            new ChapterTitleData("2.1.7b", "CEFR Self-Assessment", "mod2part1sect10"),
            new ChapterTitleData("2.1.8", "Understanding Students at Different CEFR Levels", "mod2part1sect11"),
            new ChapterTitleData("2.1.9", "The International English Language Testing System (IELTS)", "mod2part1sect12"),

            //Mod 2 PArt 2
            new ChapterTitleData("2.2.0", "Part 2 - Lesson Planning", null),
            new ChapterTitleData("2.2.1", "Practical Notes on Lesson Planning", "mod2part2sect1"),
            new ChapterTitleData("2.2.2", "Stages of a Lesson Plan", "mod2part2sect2"),
            new ChapterTitleData("2.2.3", "Warm-up Guidelines", "mod2part2sect3"),
            new ChapterTitleData("2.2.4", "Choose Age and Level-Appropriate Warm-up Exercises", "mod2part2sect4"),
            new ChapterTitleData("2.2.5", "Establishing Lesson Objectives", "mod2part2sect5"),
            new ChapterTitleData("2.2.6", "Lesson Plan Template", "mod2part2sect6"),

             //Mod 2 Quiz
            new ChapterTitleData("2.3.0", "Module 2 Quiz", null),

            //Mod 3 Part 1
            new ChapterTitleData("3.1.0", "Part 1 - Teaching Vocabulary", null),
            new ChapterTitleData("3.1.1", "Practical Approach to the Basics of Teaching Vocabulary", "mod3part1sect1"),
            new ChapterTitleData("3.1.2", "The Scope of Vocabulary Teaching Methods", "mod3part1sect2"),
            new ChapterTitleData("3.1.3", "Using Dictionaries", "mod3part1sect3"),
            new ChapterTitleData("3.1.3a", "Teaching Dictionary Skills", "mod3part1sect4"),

            //Mod 3 PArt 2

            new ChapterTitleData("3.2.0", "Part 2 - Teaching Speaking", null),
            new ChapterTitleData("3.2.1", "Basics of Foreign Language Skills", "mod3part2sect1"),
            new ChapterTitleData("3.2.2", "Teaching Speaking Skills", "mod3part2sect2"),
            new ChapterTitleData("3.2.3", "The Role of the Teacher in Teaching Speaking Skills", "mod3part2sect3"),
            new ChapterTitleData("3.2.4", "Creating a Practice Stage; A Structured Environment", "mod3part2sect4"),
            new ChapterTitleData("3.2.5", "Sample Games and Activities for Speaking Lessons", "mod3part2sect5"),
            new ChapterTitleData("3.2.6", "Correcting Errors in Speech", "mod3part2sect6"),

            //Mod 3 part 3
            new ChapterTitleData("3.3.0", "Part 3 - Teaching Reading", null),
            new ChapterTitleData("3.3.1", "Reading Skills Overview", "mod3part3sect1"),
            new ChapterTitleData("3.3.2", "Reading Approaches and Skills", "mod3part3sect2"),
            new ChapterTitleData("3.3.3", "Extensive Reading Tasks", "mod3part3sect3"),
            new ChapterTitleData("3.3.4", "Intensive Reading Tasks", "mod3part3sect4"),
            new ChapterTitleData("3.3.5", "The Role of the Teacher in Intensive Reading Lessons", "mod3part3sect5"),

            //Mod 3 part 4
            new ChapterTitleData("3.4.0", "Part 4 - Teaching Listening", null),
            new ChapterTitleData("3.4.1", "Listening Skills Overview", "mod3part4sect1"),
            new ChapterTitleData("3.4.2", "Extensive Listening Skills", "mod3part4sect2"),
            new ChapterTitleData("3.4.3", "Intensive Listening Skills", "mod3part4sect3"),
            new ChapterTitleData("3.4.4", "Using Audio Materials", "mod3part4sect4"),
            new ChapterTitleData("3.4.5", "Lesson Planning for Listening Practice", "mod3part4sect5"),

             //Mod 3 Quiz
            new ChapterTitleData("3.5.0", "Module 3 Quiz", null),

            //Mod 4 part 1
            new ChapterTitleData("4.1.0", "Part 1 -  Introduction to Classroom Management", null),
            new ChapterTitleData("4.1.1", "What is Classroom Management?", "mod4part1sect1"),
            new ChapterTitleData("4.1.2", "Routine Schedules and Punctuality", "mod4part1sect2"),
            new ChapterTitleData("4.1.3", "Preparation", "mod4part1sect3"),
            new ChapterTitleData("4.1.4", "Organizing the Classroom Layout and Expectations", "mod4part1sect4"),
            new ChapterTitleData("4.1.5", "Establishing Expectations", "mod4part1sect5"),
            new ChapterTitleData("4.1.6", "Discipline Issues", "mod4part1sect6"),
            new ChapterTitleData("4.1.6a", "Discipline Issues with Young Learners", "mod4part1sect7"),
            new ChapterTitleData("4.1.6b", "Discipline Issues with Young Adults / Teenagers", "mod4part1sect8"),
            new ChapterTitleData("4.1.6c", "Discipline Issues with Adults", "mod4part1sect9"),

            //mod 4 part 2

            new ChapterTitleData("4.2.0", "Part 2 -  Final Guidance Notes", null),
            new ChapterTitleData("4.2.1", "The Final Exam", "mod4part2sect1"),
            new ChapterTitleData("4.2.2", "The Lesson Plan Assignment", "mod4part2sect2"),
            new ChapterTitleData("4.2.3", "Conclusion", "mod4part2sect3"),

             //Mod 4 Quiz
            new ChapterTitleData("4.3.0", "Module 4 Quiz", null),
        };

        #endregion Public Fields
    }

    public class ChapterTitleData
    {
        #region Public Constructors

        public ChapterTitleData(string num, string title, string sectionID)
        {
            Number = num;
            Title = title;
            SectionID = sectionID;
        }

        #endregion Public Constructors

        #region Public Properties

        public string Number { get; set; }
        public string SectionID { get; set; }
        public string Title { get; set; }

        #endregion Public Properties
    }
}