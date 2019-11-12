using System.Collections.Generic;
using System.Linq;

namespace TEFL_App.Helpers
{
    public static class QuizQuestions
    {
        #region Private Fields

        public static readonly List<TestQuestion> Questions = new List<TestQuestion>() {
    // ************************* Mod1

    new TestQuestion(
        ModuleNumber.Mod1,
        QuestionType.SingleChoice,
        "Which language teaching method consists of classes being taught in students' native language, a focus on memorizing vocabulary, and in depth grammar explanations ?",
        new List<string> {
            "Grammar-Translation Method",
            "Direct Method",
            "Intensive Method",
            "Audiolingual Method"
        },
        new List<int> { 0 }

    ),
    new TestQuestion(
        ModuleNumber.Mod1,
        QuestionType.MultipleChoice,
        "What is true about the Audiolingual Method?",
        new List<string>{
            "Heavy emphasis on pronunciation",
            "Limited use of native language during teaching",
            "Very little grammar explanation",
        },
        new List<int> { 0, 1, 2}
    ),
    new TestQuestion(
        ModuleNumber.Mod1,
        QuestionType.SingleChoice,
        "Which language teaching method is based upon the way children learn their native language?",
        new List<string>{
            "Total Physical Response (TPR)",
            "Communicative Language Teaching (CLT)",
            "Suggestopedia",
            "All methods",
        },
        new List<int> { 0}
    ),
    new TestQuestion(
        ModuleNumber.Mod1,
        QuestionType.SingleChoice,
        "The following are all pronouns except:",
        new List<string>{
            "Anyone",
            "His",
            "They",
            "Team"
        },
       new List<int> { 3}
    ),
    new TestQuestion(
        ModuleNumber.Mod1,
        QuestionType.SingleChoice,
        "The following are all prepositions except:",
        new List<string>{
            "On",
            "In",
            "Yesterday",
            "Under"
        },
        new List<int> { 2}
    ),
    new TestQuestion(
        ModuleNumber.Mod1,
        QuestionType.SingleChoice,
        "Help! Ouch! Wow! Are examples of what part of speech?",
        new List<string>{
            "Intrinsic verbs",
            "Interjections",
            "Onomatopoeia",
            "Preterite"
        },
       new List<int> { 1}
    ),
    new TestQuestion(
        ModuleNumber.Mod1,
        QuestionType.SingleChoice,
        "Which sentence is an example of simple present tense?",
       new List<string> {
            "She works in the tech industry.",
            "She is working in the tech industry.",
            "She has been working in the tech industry.",
            "She worked in the tech industry."
        },
        new List<int> { 0}
    ),
    new TestQuestion(
        ModuleNumber.Mod1,
        QuestionType.SingleChoice,
        "Which of these sentences is an example of future progressive tense?",
       new List<string> {
            "He was unwilling to open the door.",
            "He will be opening the door as soon as he comes down to the mezzanine.",
            "He is heading to the door now.",
            "He might meet you at the door."
        },
       new List<int> { 1}
    ),

    // ************************* Mod2

    new TestQuestion(
        ModuleNumber.Mod2,
        QuestionType.SingleChoice,
        "Which statement is untrue about how young/early learners learn a new language?",
        new List<string>{
            "Grammar rules are easy to grasp",
            "Their understanding comes from all senses (hearing, touching, seeing, etc.)",
            "They learn indirectly, rather than directly",
            "They have a need for attention and approval from their teacher(s)"
        },
       new List<int> { 0}

    ),
    new TestQuestion(
        ModuleNumber.Mod2,
        QuestionType.SingleChoice,
        "Which age group of students is most likely to be critical or skeptical of a teacher's methods and ability?",
       new List<string> {
            "Young/early learners",
            "Young adult learners",
            "Adult learners",
            "All ages can be this way"
        },
       new List<int> { 2}

    ),
    new TestQuestion(
        ModuleNumber.Mod2,
        QuestionType.SingleChoice,
        "According to the global scale for ranking second language proficiency, based on the Common European Framework of Reference(CEFR), what is the correct order of language levels from least proficient to most proficient?",
        new List<string>{
            "C1, C2, B1, B2, A1, A2",
            "4.0, 4.5, 5.0, 5.5, 6.0, 6.5, 7.0, 7.5, 8.0, 8.5, 9.0",
            "C1, B1, A1, C2, B2, A2",
            "A1, A2, B1, B2, C1, C2"
        },
       new List<int> { 3}

    ),
    new TestQuestion(
        ModuleNumber.Mod2,
        QuestionType.MultipleChoice,
        "Students typically study the International English Language Testing System (IELTS) for what purpose?",
       new List<string> {
            "International school and college entrance requirements",
            "Immigration requirements",
            "Resume Building",
        },
        new List<int> { 0, 1}

    ),
    new TestQuestion(
        ModuleNumber.Mod2,
        QuestionType.SingleChoice,
        "Approximately how many stages do we suggest that you include in your lesson plan?",
       new List<string> {
            "2",
            "6",
            "12",
            "As many as necessary"
        },
       new List<int> { 1}

    ),
    new TestQuestion(
        ModuleNumber.Mod2,
        QuestionType.SingleChoice,
        "During a warm up stage how much time should the teacher spend talking?",
        new List<string>{
            "Almost all of the time. Let the students just listen and relax.",
            "Very little; about 20% of the time"
        },
       new List<int> { 1}

    ),
    new TestQuestion(
        ModuleNumber.Mod2,
        QuestionType.SingleChoice,
        "When should a warm up stage not be included in one day's lesson plan?",
        new List<string>  {
            "On test and quiz days",
            "The warm up stage should always be included at the beginning of every lesson",
            "When the class size is less than 10 students",
            "When the lesson plan is reading-intensive"
        },
        new List<int>{1}

    ),
    new TestQuestion(
        ModuleNumber.Mod2,
        QuestionType.SingleChoice,
        "To which age group should you assign children's books as reading material?",
       new List<string> {
            "Young/early learners",
            "Young adult learners",
            "Adult learners",
            "The age of students does not matter, the language level matters. Therefore, children's books are appropriate for any age group."
        },
        new List<int> { 3}

    ),

    // ************************* Mod3

    new TestQuestion(
        ModuleNumber.Mod3,
        QuestionType.SingleChoice,
        "In the context of teaching vocabulary, from what teaching methodology or theory is miming derived?",
       new List<string> {
            "Grammar-Translation",
            "Total Physical Response (TPR)",
            "The Direct Method",
            "Suggestopedia"
        },
        new List<int> { 1}

    ),
    new TestQuestion(
        ModuleNumber.Mod3,
        QuestionType.SingleChoice,
        "What are the four basic language skills?",
       new List<string> {
            "Fluency, intuition, comprehension, and paraphrasing",
            "Usage, grammar, vocabulary, and pronunciation",
            "Reading comprehension, writing, listening comprehension, and oral production (speaking)",
            "Grammar, pronunciation, intonation, and vocabulary"
        },
        new List<int> { 2}

    ),
    new TestQuestion(
        ModuleNumber.Mod3,
        QuestionType.SingleChoice,
        "What is our suggested way to encourage shy or reluctant students to participate in speaking exercises?",
       new List<string> {
            "Break up the class into small groups",
            "Make speaking in front of classmates mandatory",
            "Give them printed material from which to read verbatim",
            "Reduce the complexity or level of speaking exercises to accommodate lower-level students"
        },
       new List<int> { 0}

    ),
    new TestQuestion(
        ModuleNumber.Mod3,
        QuestionType.SingleChoice,
        "What are the four language \"sub-skills\"?",
       new List<string> {
            "Grammar, pronunciation, vocabulary, and spelling",
            "Grammar, pronunciation, intonation, and vocabulary",
            "Reading comprehension, writing, listening comprehension, and oral production (speaking)",
            "Tone, rhythm, intonation, and style"
        },
        new List<int>  {0}

    ),
    new TestQuestion(
        ModuleNumber.Mod3,
        QuestionType.SingleChoice,
        "In which approach to teaching reading will a teacher require students to avoid reading every word of the text, but will instead guide the students through the headers, photographs, the structure of the reading assignment, etc., and will generally encourage the students to skim?",
       new List<string> {
            "The bird's eye view approach",
            "The skimming approach",
            "The top-down approach",
            "The superficial approach"
        },
        new List<int>  {2}

    ),
    new TestQuestion(
        ModuleNumber.Mod3,
        QuestionType.SingleChoice,
        "In which approach to teaching reading will a teacher require students to focus on a group of sentences or words, asking comprehension questions or association questions(e.g., 'Is anyone allergic to his food ingredient?', or, 'What dishes include this ingredient that you like to eat?'), and so on?",
       new List<string> {
            "The bottom-up approach",
            "The focused approach",
            "The skimming approach",
            "The interactive approach"
        },
        new List<int>  {0}

    ),
    new TestQuestion(
        ModuleNumber.Mod3,
        QuestionType.SingleChoice,
        "In which approach should learners practise re-telling in their own words what the general meaning of the text is?",
       new List<string> {
            "The interactive approach",
            "Personal evaluation",
            "Generalization",
            "Paraphrasing"
        },
       new List<int> { 3}

    ),
    new TestQuestion(
        ModuleNumber.Mod3,
        QuestionType.SingleChoice,
        "Which of the following tools or methods should the teacher use when practicing intensive listening skills?",
        new List<string>{
            "Podcasts, MP3s, CDs, TV programs",
            "Graded readers to be read aloud",
            "One-on-One listening practice",
            "Dictation of teacher's monologues"
        },
      new List<int> { 0}

    ),

    // ************************* Mod4

    new TestQuestion(
        ModuleNumber.Mod4,
        QuestionType.SingleChoice,
        "In what way do we suggest that teachers instil punctuality?",
      new List<string>  {
            "Discipline students in front of the class when they are late",
            "Lock the door at the time class begins to prevent tardy students from joining",
            "The teacher should arrive at least a couple of minutes early and greet students at the door as they arrive",
            "Create a reward system for students who arrive early and are prepared for class"
        },
       new List<int> { 2}

    ),
    new TestQuestion(
        ModuleNumber.Mod4,
        QuestionType.SingleChoice,
        "Whose responsibility is it for disciplining students (mild disciplinary issues)?",
       new List<string> {
            "The head master / principal",
            "You, the teacher",
            "Students' parents",
            "The office admin staff"
        },
       new List<int> { 1}

    ),
    new TestQuestion(
        ModuleNumber.Mod4,
        QuestionType.SingleChoice,
        "What are the four stages of \"Moral Development\", according to Lawrence Kohlberg?",
        new List<string>{
            "The \"Power\" stage, the \"Reward-Punishment\" stage, the \"How can I please you?\" stage, the \"Social Order\" stage",
            "The \"Guidance\" stage, the \"Social involvement\" stage, the \"Award and recognition\" stage, the \"Hypercritical\" stage",
            "The \"Guidance\" stage, the \"Social involvement\" stage, the \"Award and recognition\" stage, the \"Independence\" stage",
            "The \"Power\" stage, the \"Reward-Punishment\" stage, the \"How can I please you ? \" stage, the \"Conformity\" stage"
        },
       new List<int> { 0}

    ),
    new TestQuestion(
        ModuleNumber.Mod4,
        QuestionType.MultipleChoice,
        "What are the common discipline issues associated with adult students?",
       new List<string> {
            "Rambling, getting off topic, and being unfocused in class",
            "Talkativeness, especially to impress peers and the teacher",
            "Shyness or silence",
        },
        new List<int> {0, 1, 2}

    ),

    // ************************* Final Exam
    //1
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "In which age group do students struggle most with improving their pronunciation?",
      new List<string>  {
            "Early/young learners",
            "Adults",
            "Young adults / adolescents",
            "It depends on the native language"
        },
         new List<int> { 1}
    ),//2
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "Which language teaching method consists of classes being taught in students' native language, a focus on memorizing vocabulary, and in depth grammar explanations?",
       new List<string> {
            "Grammar-Translation Method",
            "Direct Method",
            "Intensive Method",
            "Audiolingual Method"
        },
        new List<int> { 0}
    ),//3
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "Which language teaching method is based upon the way children learn their native language?",
       new List<string> {
            "Total Physical Response (TPR)",
            "Communicative Language Teaching (CLT)",
            "Suggestopedia",
            "All methods"
        },
        new List<int> { 0}
    ),//4
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "The following are all pronouns except:",
       new List<string> {
            "Anyone",
            "His",
            "They",
            "Team"
        },
        new List<int> { 3}
    ),//5
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "The following are all prepositions except:",
       new List<string> {
            "On",
            "In",
            "Yesterday",
            "Under"
        },
       new List<int> { 2}
    ),//6
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "What is the first stage of a lesson plan?",
     new List<string>   {
            "Presentation",
            "Warm-up / Review",
            "Attendance",
            "Introduction"
        },
       new List<int> { 1}
    ),//7
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "Help! Ouch! Wow! Are examples of what part of speech?",
    new List<string>    {
            "Intrinsic Verbs",
            "Interjections",
            "Onomatopoeia",
            "Preterite"
        },
        new List<int> { 1}
    ),//8
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "Which sentence below is an example of simple present tense?",
       new List<string> {
            "She works in the tech industry.",
            "She is working in the tech industry.",
            "She has been working in the tech industry.",
            "She worked in the tech industry."
        },
       new List<int> { 0}
    ),//9
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "Which statement is untrue about how young/early learners learn a new language?",
       new List<string> {
            "Grammar rules are easy to grasp",
            "Their understanding comes from all senses (hearing, touching, seeing, etc.)",
            "They learn indirectly, rather than directly",
            "They have a need for attention and approval from their teacher/s"
        },
        new List<int> { 0}
    ),//10
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "Which age group of students is most likely to be critical or skeptical of a teacher's methods and ability ?",
        new List<string>{
            "Young/early learners",
            "Young adult learners",
            "Adult learners",
            "All ages can be this way"
        },
        new List<int> { 2}
    ),//11
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "According to the global scale for ranking second language proficiency, based on the Common European Framework of Reference(CEFR), what is the correct order of language levels from least proficient to most proficient?",
       new List<string> {
            "C1, C2, B1, B2, A1, A2",
            "4.0, 4.5, 5.0, 5.5, 6.0, 6.5, 7.0, 7.5, 8.0, 8.5, 9.0",
            "C1, B1, A1, C2, B2, A2",
            "A1, A2, B1, B2, C1, C2"
        },
        new List<int> { 3}
    ),//12
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "Approximately how many stages do we suggest that you include in your lesson plan?",
        new List<string>{
            "2",
            "6",
            "12",
            "As many as necessary"
        },
       new List<int> { 1}
    ),//13
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "When should a warm up stage not be included in one day's lesson plan?",
     new List<string>   {
            "On test and quiz days",
            "The warm up stage should always be included at the beginning of every lesson",
            "When the class size is less than 10 students",
            "When the lesson plan is reading-intensive"
        },
        new List<int> { 1}
    ),//14
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "The method of vocabulary teaching in which the teacher asks students about a particular word before explaining its meaning or context, creating a student-centered classroom is called what?",
     new List<string>   {
            "Micromanaging",
            "Macromanaging",
            "Elicitation",
            "Word Discovery"
        },
         new List<int> { 2}
    ),//15
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "One means to elicit vocabulary is by putting a key word in a circle then getting students to brainstorm related words and synonyms. This method of teaching vocabulary is called:",
     new List<string>   {
            "Visualization",
            "Mind mapping",
            "Relative reasoning",
            "Association drills"
        },
        new List<int> { 1}
    ),//16
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "In the context of teaching vocabulary, from what teaching methodology or theory is miming derived?",
       new List<string> {
            "Suggestopedia",
            "Grammar-Translation",
            "The Direct Method",
            "Total Physical Response (TPR)"
        },
         new List<int> { 3}
    ),//17
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "What is our suggested way to encourage shy or reluctant students to participate in speaking exercises?",
        new List<string>{
            "Break up the class into small groups",
            "Make speaking in front of classmates mandatory",
            "Give them printed material from which to read verbatim",
            "Reduce the complexity or level of speaking exercises to accommodate lower-level students",
        },
       new List<int> { 0}
    ),//18
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "In which approach should learners practise re-telling in their own words what the general meaning of the text is?",
       new List<string> {
            "The interactive approach",
            "Personal evaluation",
            "Generalization",
            "Paraphrasing"
        },
        new List<int> { 3}
    ),//19
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "The ________ language teaching methodology includes using L1 to teach L2, memorizing vocabulary, and explaining grammar in depth.",
        new List<string>{
            "Direct method",
            "Chinese method",
            "Grammar-Translation method",
            "Suggestopedia"
        },
        new List<int> { 2}
    ),//20
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "In reference to the CEFR's 'Global Scale', what is the highest level of prociency in a second language?",
      new List<string>  {
            "C3",
            "A1",
            "D3",
            "C2"
        },
        new List<int> { 3}
    ),//21
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "\"anyone\", \"somebody\", and \"anybody\" are all examples of __________.",
       new List<string> {
            "Personal pronouns",
            "Sentence subjects",
            "Relative nouns",
            "Indefinite pronouns"
        },
         new List<int> { 3}
    ),//22
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "In which age group are students most likely to ramble (wandering off-topic or using nonsensical analogies and metaphors)?",
        new List<string>{
            "Adults",
            "Young / early learners",
            "Young Adults / adolescents",
            "Depends on language level"
        },
       new List<int> { 0}
    ),//23
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "What English language testing system/s is often used by universities and other academic institutions to evaluate a student's English level and to determine benchmarks for enrollment requirements?",
      new List<string>  {
            "CEFR",
            "IELTS and/or TOEFL",
            "American English Standard Test",
            "ELLAS"
        },
         new List<int> { 1}
    ),//24
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "Students of which age group are most likely to persist through lessons, despite diculty and boredom?",
      new List<string>  {
            "Young / early learners",
            "Young adults / adolescents",
            "Adults",
            "It depends of the local culture"
        },
        new List<int> { 2}
    ),//25
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "On the topic of language teaching theories and methodologies, to what does the acronym \"TPR\" refer?",
       new List<string> {
            "Teaching Proficiency Rating",
            "Tertiary Points of Reference",
            "Typology, Pronunciation and Repetition",
            "Total Physical Response"
        },
        new List<int> { 3}
    ),//26
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "In what way do we suggest that teachers model punctuality?",
     new List<string>   {
            "Discipline students in front of the class when they are late",
            "Lock the door at the time class begins to prevent tardy students from joining",
            "The teacher should arrive at least a couple minutes early and greet students at the door as they arrive",
            "Create a reward system for students who arrive early and prepared for class"
        },
       new List<int> { 2}
    ),//27
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "Who, what, where, when, how, and why are examples of what part of speech?",
     new List<string>   {
            "Personal pronouns",
            "Question pronouns",
            "Interrogative pronouns",
            "Relative pronouns"
        },
      new List<int> { 2}
    ),//28
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "Which of the following are examples of superlative adjectives?",
        new List<string>{
            "biggest, richest, best",
            "great, massive, tremendous",
            "acute, sharp, intrusive",
            "faster, stronger, prettier"
        },
       new List<int> { 0}
    ),//29
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "Which verbs do not require an object to complete a sentence? For example: The man yelled.",
       new List<string> {
            "Short-type verbs",
            "Yielding verbs",
            "Irregular verbs",
            "Intransitive verbs"
        },
       new List<int> { 3}
    ),//30
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "What are the four stages of \"Moral Development\", according to Lawrence Kohlberg?",
      new List<string>  {
            "The \"Power\" stage, the \"Reward-Punishment\" stage, the \"How can I please you?\" stage, the \"Social Order\" stage",
            "The \"Guidance\" stage, the \"Social involvement\" stage, the \"Award and recognition\" stage, the \"Hypercritical\" stage",
            "The \"Guidance\" stage, the \"Social involvement\" stage, the \"Award and recognition\" stage, the \"Independence\" stage",
            "The \"Power\" stage, the \"Reward-Punishment\" stage, the \"How can I please you ? \" stage, the \"Conformity\" stage"
        },
        new List<int> { 0}
    ),//31
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "Which of the following is an example of a sentence written with an active voice?",
        new List<string>{
            "He finished his work.",
            "The work was completed by him.",
            "He was given more work after he finished his previous tasks",
            "All of the above"
        },
       new List<int> { 0}
    ),//32
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "According to the CEFR, at which common reference level (CRL) can a student: \"understand a wide range of demanding, longer texts, and recognise implicit meaning. Can express him/herself fluently and spontaneously without much obvious searching for expressions. Can use language flexibly and effectively for social, academic and professional purposes. Can produce clear, well structured, detailed text on complex subjects, showing controlled use of organisational patterns, connectors and cohesive devices.\" ?",
      new List<string>  {
            "A1",
            "C3",
            "B2",
            "C1"
        },
        new List<int> { 3}
    ),//33
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "In which age group are students least likely to feel embarrassed about making mistakes in public?",
     new List<string>   {
            "Adults",
            "Young adults / adolescents",
            "Young / early learners",
            "College students"
        },
        new List<int> { 2}
    ),//34
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "The theory of _________ broadens the traditional view of intelligence as solely composed of verbal / linguistic and logical / mathematical abilities. It maintains that all humans possess at least eight different intelligences that represent a variety of ways to learn and demonstrate understanding.",
       new List<string> {
            "Complex mental tasking",
            "Multiple Intelligences (MI)",
            "Non-binary Intelligence (NBI)",
            "The Eight Intellegences"
        },
         new List<int> { 1}
    ),//35
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "Unless activities are extremely engaging, _________ can get bored easily, losing interest after ten minutes or so, because of their limited attention span.",
      new List<string>  {
            "Young / early learners",
            "Adults",
            "Young adults / adolescents",
            "All of the above"
        },
       new List<int> { 0}
    ),//36
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "In the Communicative Language Teaching methodology, what is meant by the 'PPP' lesson shape?",
       new List<string> {
            "Preparation, Practice, Performance",
            "Presentation, Practice, Production",
            "Predetermine (the student's needs), Postulate, Paraphrase",
            "PPP describes the shape of desk arrangements in a classroom"
        },
       new List<int> { 1}
    ),//37
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "_______ is/are very important in grammar since they are the groups in which words are categorized. They allow you to label a word in a sentence and provide the framework for the rules to follow in that sentence.",
      new List<string>  {
            "Punctuation",
            "Parts of speech",
            "Lexical categories",
            "Abstraction"
        },
       new List<int> { 1}
    ),//38
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "With which age group will a teacher deal with the most discipline issues?",
       new List<string> {
            "Young / early learners",
            "Young adults / adolescents",
            "Adults",
            "Discipline issues can occur with all age groups more or less equally",
        },
        new List<int> { 3}
    ),//39
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "___________ must be encouraged to respond to texts and situations with their ownthoughts and experiences, rather than just by answering questions and doing disconnected learning activities.",
     new List<string>   {
            "Adults",
            "Young / early learners",
            "Young adults / adolescents",
            "Students (generally)"
        },
       new List<int> { 2}
    ),//40
    new TestQuestion(
        ModuleNumber.FinalExam,
        QuestionType.SingleChoice,
        "_______________ involves reading a text quickly to get a general idea of the main topic.",
      new List<string>  {
            "Skimming",
            "Fast-reading",
            "Outlining",
            "The Top-down approach"
        },
         new List<int> { 0}
    )
        };

        #endregion Private Fields

        public static List<TestQuestion> GetQuestions(ModuleNumber module)
        {
            Questions.ResetQuestions();

            return Questions.Where(x => x.Module == module).ToList();
        }

        /// <summary>
        /// Rests the state of all questions.
        /// </summary>
        /// <param name="Qs"></param>
        public static void ResetQuestions(this List<TestQuestion> Qs)
        {
            foreach(var q in Qs)
            {
                q.SelectedAnswers.Clear();
            }
        }

        /******************/
    }
}