import '../types/class_subject.dart';

/// Represents a teacher in the school system.
///
/// Models remain pure Dart, independent of Flutter UI components.
class TeacherModel {
  final String id;
  final String name;
  final ClassSubject primarySubject;

  const TeacherModel({
    required this.id,
    required this.name,
    required this.primarySubject,
  });
}
