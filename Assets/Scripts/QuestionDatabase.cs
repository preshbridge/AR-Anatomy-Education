using System.Collections.Generic;

public static class QuestionDatabase
{
    public static List<Question> GetQuestions(string muscle)
    {
        switch (muscle)
        {
            case "Deltoid":
                return GetDeltoidQuestions();

            case "Supraspinatus":
                return GetSupraspinatusQuestions();

            case "Infraspinatus":
                return GetInfraspinatusQuestions();

            case "Teres Minor":
                return GetTeresMinorQuestions();

            case "Subscapularis":
                return GetSubscapularisQuestions();

            case "Biceps Brachii":
                return GetBicepsQuestions();

            case "Brachialis":
                return GetBrachialisQuestions();

            case "Coracobrachialis":
                return GetCoracobrachialisQuestions();

            case "Triceps Brachii":
                return GetTricepsQuestions();

          case "Brachioradialis":
    return GetBrachioradialisQuestions();

            case "Flexor Carpi Radialis":
                return GetFlexorCarpiRadialisQuestions();

            case "Palmaris Longus":
                return GetPalmarisLongusQuestions();

            case "Flexor Carpi Ulnaris":
                return GetFlexorCarpiUlnarisQuestions();

            default:
                return new List<Question>();
        }
    }
    static List<Question> GetDeltoidQuestions()
{
    return new List<Question>()
    {
        new Question(
            "What is the primary function of the Deltoid?",
            new string[]{
                "Arm Abduction",
                "Finger Flexion",
                "Hip Extension",
                "Neck Rotation"
            },0),

        new Question(
            "Where is the Deltoid located?",
            new string[]{
                "Shoulder",
                "Forearm",
                "Chest",
                "Leg"
            },0),

        new Question(
            "Which bone does the Deltoid attach to?",
            new string[]{
                "Humerus",
                "Femur",
                "Radius",
                "Ulna"
            },0),

        new Question(
            "The Deltoid stabilizes the ____?",
            new string[]{
                "Shoulder Joint",
                "Knee",
                "Ankle",
                "Hip"
            },0),

        new Question(
            "The Deltoid is shaped like a?",
            new string[]{
                "Triangle",
                "Circle",
                "Square",
                "Rectangle"
            },0),
    };
}
static List<Question> GetSupraspinatusQuestions()
{
    return new List<Question>()
    {
        new Question(
            "The Supraspinatus belongs to which muscle group?",
            new string[]{
                "Rotator Cuff",
                "Quadriceps",
                "Hamstrings",
                "Abdominals"
            },0),

        new Question(
            "The Supraspinatus helps initiate?",
            new string[]{
                "Arm Abduction",
                "Knee Flexion",
                "Hip Rotation",
                "Finger Extension"
            },0),

        new Question(
            "Where is the Supraspinatus located?",
            new string[]{
                "Top of the Scapula",
                "Forearm",
                "Leg",
                "Chest"
            },0),

        new Question(
            "The Supraspinatus stabilizes the?",
            new string[]{
                "Shoulder",
                "Ankle",
                "Knee",
                "Neck"
            },0),

        new Question(
            "The Supraspinatus attaches to the?",
            new string[]{
                "Humerus",
                "Femur",
                "Radius",
                "Tibia"
            },0),
    };
}
static List<Question> GetInfraspinatusQuestions()
{
    return new List<Question>()
    {
        new Question("The Infraspinatus belongs to which muscle group?",
            new string[]{"Rotator Cuff","Hamstrings","Quadriceps","Abdominals"},0),

        new Question("The Infraspinatus mainly performs?",
            new string[]{"External Rotation","Elbow Flexion","Wrist Extension","Hip Flexion"},0),

        new Question("Where is the Infraspinatus located?",
            new string[]{"Back of the Scapula","Forearm","Chest","Leg"},0),

        new Question("The Infraspinatus helps stabilize the?",
            new string[]{"Shoulder Joint","Knee","Ankle","Hip"},0),

        new Question("The Infraspinatus attaches to the?",
            new string[]{"Humerus","Femur","Radius","Ulna"},0)
    };
}

static List<Question> GetTeresMinorQuestions()
{
    return new List<Question>()
    {
        new Question("Teres Minor is part of the?",
            new string[]{"Rotator Cuff","Quadriceps","Hamstrings","Calf"},0),

        new Question("The Teres Minor performs?",
            new string[]{"External Rotation","Finger Flexion","Walking","Jaw Movement"},0),

        new Question("The Teres Minor is located on the?",
            new string[]{"Shoulder","Forearm","Leg","Chest"},0),

        new Question("The Teres Minor helps stabilize the?",
            new string[]{"Shoulder","Ankle","Hip","Knee"},0),

        new Question("The Teres Minor attaches to the?",
            new string[]{"Humerus","Femur","Tibia","Radius"},0)
    };
}

static List<Question> GetSubscapularisQuestions()
{
    return new List<Question>()
    {
        new Question("The Subscapularis belongs to which group?",
            new string[]{"Rotator Cuff","Quadriceps","Hamstrings","Abdominals"},0),

        new Question("The Subscapularis performs?",
            new string[]{"Internal Rotation","External Rotation","Elbow Extension","Neck Rotation"},0),

        new Question("The Subscapularis is found on the?",
            new string[]{"Front of the Scapula","Forearm","Leg","Chest"},0),

        new Question("The Subscapularis stabilizes the?",
            new string[]{"Shoulder","Hip","Ankle","Knee"},0),

        new Question("The Subscapularis attaches to the?",
            new string[]{"Humerus","Femur","Ulna","Radius"},0)
    };
}

static List<Question> GetBicepsQuestions()
{
    return new List<Question>()
    {
        new Question("The Biceps Brachii mainly performs?",
            new string[]{"Elbow Flexion","Knee Extension","Hip Flexion","Wrist Extension"},0),

        new Question("The Biceps Brachii is located in the?",
            new string[]{"Upper Arm","Forearm","Shoulder","Leg"},0),

        new Question("How many heads does the Biceps Brachii have?",
            new string[]{"Two","One","Three","Four"},0),

        new Question("The Biceps Brachii also helps with?",
            new string[]{"Supination","Walking","Breathing","Chewing"},0),

        new Question("The Biceps Brachii crosses which joints?",
            new string[]{"Shoulder and Elbow","Hip and Knee","Wrist and Fingers","Ankle and Knee"},0)
    };
}

static List<Question> GetBrachialisQuestions()
{
    return new List<Question>()
    {
        new Question("The Brachialis is the strongest?",
            new string[]{"Elbow Flexor","Shoulder Extensor","Wrist Extensor","Hip Flexor"},0),

        new Question("The Brachialis lies underneath the?",
            new string[]{"Biceps Brachii","Triceps","Deltoid","Brachioradialis"},0),

        new Question("The Brachialis is located in the?",
            new string[]{"Upper Arm","Forearm","Shoulder","Leg"},0),

        new Question("The Brachialis inserts on the?",
            new string[]{"Ulna","Radius","Femur","Scapula"},0),

        new Question("The main action of the Brachialis is?",
            new string[]{"Elbow Flexion","Shoulder Rotation","Finger Extension","Hip Extension"},0)
    };
}

static List<Question> GetCoracobrachialisQuestions()
{
    return new List<Question>()
    {
        new Question("The Coracobrachialis is found in the?",
            new string[]{"Upper Arm","Forearm","Leg","Chest"},0),

        new Question("The Coracobrachialis assists with?",
            new string[]{"Shoulder Flexion","Knee Flexion","Wrist Extension","Neck Rotation"},0),

        new Question("The Coracobrachialis helps bring the arm?",
            new string[]{"Toward the body","Away from the body","Behind the back","Below the waist"},0),

        new Question("The Coracobrachialis originates from the?",
            new string[]{"Coracoid Process","Clavicle","Radius","Ulna"},0),

        new Question("The Coracobrachialis stabilizes the?",
            new string[]{"Shoulder","Knee","Ankle","Hip"},0)
    };
}

static List<Question> GetTricepsQuestions()
{
    return new List<Question>()
    {
        new Question("The Triceps Brachii mainly performs?",
            new string[]{"Elbow Extension","Elbow Flexion","Shoulder Abduction","Finger Flexion"},0),

        new Question("The Triceps Brachii is located on the?",
            new string[]{"Back of the Upper Arm","Front of the Forearm","Shoulder","Leg"},0),

        new Question("How many heads does the Triceps have?",
            new string[]{"Three","One","Two","Four"},0),

        new Question("The Triceps assists with?",
            new string[]{"Shoulder Extension","Knee Flexion","Wrist Rotation","Neck Movement"},0),

        new Question("The Triceps inserts on the?",
            new string[]{"Olecranon of Ulna","Radius","Scapula","Femur"},0)
    };
}

static List<Question> GetBrachioradialisQuestions()
{
    return new List<Question>()
    {
        new Question("The Brachioradialis is located in the?",
            new string[]{"Forearm","Upper Arm","Shoulder","Leg"},0),

        new Question("The Brachioradialis mainly performs?",
            new string[]{"Elbow Flexion","Shoulder Flexion","Knee Extension","Finger Extension"},0),

        new Question("The Brachioradialis works best when the hand is?",
            new string[]{"In a Neutral Position","Fully Pronated","Fully Supinated","Closed"},0),

        new Question("The Brachioradialis is found on the?",
            new string[]{"Lateral Forearm","Medial Thigh","Chest","Back"},0),

        new Question("The Brachioradialis assists in?",
            new string[]{"Forearm Rotation","Walking","Breathing","Chewing"},0)
    };
}

static List<Question> GetFlexorCarpiRadialisQuestions()
{
    return new List<Question>()
    {
        new Question("The Flexor Carpi Radialis is located in the?",
            new string[]{"Forearm","Upper Arm","Shoulder","Leg"},0),

        new Question("The Flexor Carpi Radialis mainly performs?",
            new string[]{"Wrist Flexion","Shoulder Rotation","Knee Extension","Finger Extension"},0),

        new Question("The Flexor Carpi Radialis also performs?",
            new string[]{"Hand Abduction","Hip Flexion","Neck Rotation","Jaw Movement"},0),

        new Question("The Flexor Carpi Radialis is found on the?",
            new string[]{"Anterior Forearm","Back","Leg","Chest"},0),

        new Question("The Flexor Carpi Radialis acts on the?",
            new string[]{"Wrist","Knee","Shoulder","Ankle"},0)
    };
}

static List<Question> GetPalmarisLongusQuestions()
{
    return new List<Question>()
    {
        new Question("The Palmaris Longus is located in the?",
            new string[]{"Forearm","Shoulder","Leg","Neck"},0),

        new Question("The Palmaris Longus helps with?",
            new string[]{"Wrist Flexion","Elbow Extension","Hip Rotation","Knee Flexion"},0),

        new Question("The Palmaris Longus tightens the?",
            new string[]{"Palmar Fascia","Achilles Tendon","Quadriceps","Hamstrings"},0),

        new Question("The Palmaris Longus is absent in some?",
            new string[]{"People","Animals","Bones","Muscles"},0),

        new Question("The Palmaris Longus belongs to the?",
            new string[]{"Anterior Forearm","Posterior Leg","Chest","Back"},0)
    };
}

static List<Question> GetFlexorCarpiUlnarisQuestions()
{
    return new List<Question>()
    {
        new Question("The Flexor Carpi Ulnaris is located in the?",
            new string[]{"Forearm","Shoulder","Upper Arm","Leg"},0),

        new Question("The Flexor Carpi Ulnaris mainly performs?",
            new string[]{"Wrist Flexion","Shoulder Extension","Knee Flexion","Hip Rotation"},0),

        new Question("The Flexor Carpi Ulnaris also performs?",
            new string[]{"Hand Adduction","Walking","Breathing","Chewing"},0),

        new Question("The Flexor Carpi Ulnaris is found on the?",
            new string[]{"Anterior Forearm","Back","Chest","Leg"},0),

        new Question("The Flexor Carpi Ulnaris acts on the?",
            new string[]{"Wrist","Ankle","Hip","Shoulder"},0)
    };
}
}