/// Represents a student in the school system.
///
/// In MAUI, this might be a C# record. In Flutter, domain models should 
/// ideally be immutable (using `final` fields).
class StudentModel {
  final String id;
  final String name;
  final bool isEnrolled;

  const StudentModel({
    required this.id,
    required this.name,
    this.isEnrolled = false,
  });

  /// Creates a new copy of the object, modifying the provided fields.
  StudentModel copyWith({
    String? id,
    String? name,
    bool? isEnrolled,
  }) {
    return StudentModel(
      id: id ?? this.id,
      name: name ?? this.name,
      isEnrolled: isEnrolled ?? this.isEnrolled,
    );
  }
}
