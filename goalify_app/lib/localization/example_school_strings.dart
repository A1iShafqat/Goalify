/// A simple placeholder for managing text resources.
///
/// MAUI handles localization with .resx files. Flutter typically uses 
/// .arb files with the `flutter_localizations` package. Until we configure 
/// the full localization pipeline, this class serves as a central place 
/// for static strings to avoid hardcoding text in UI widgets.
class SchoolStrings {
  static const String appName = 'School Manager';
  static const String classRosterTitle = 'Class Roster';
  static const String enrollButton = 'Enroll New Student';
  static const String teacherLabel = 'Teacher: ';

  // Prevent instantiation
  SchoolStrings._();
}
