import '../data/models/student_model.dart';
import '../data/models/teacher_model.dart';
import '../data/types/class_subject.dart';

/// Abstract interface for fetching school data.
///
/// In MAUI, you register this interface in the DI container.
abstract class SchoolService {
  Future<TeacherModel> getTeacherInfo();
  Future<List<StudentModel>> getStudentsInClass();
  Future<void> enrollStudent(StudentModel student);
}

/// Mock implementation for early development.
class MockSchoolService implements SchoolService {
  final List<StudentModel> _students = [
    const StudentModel(id: '1', name: 'Alice Smith', isEnrolled: true),
    const StudentModel(id: '2', name: 'Bob Jones', isEnrolled: true),
  ];

  @override
  Future<TeacherModel> getTeacherInfo() async {
    await Future.delayed(const Duration(milliseconds: 300));
    return const TeacherModel(
      id: 't1', 
      name: 'Mr. Anderson', 
      primarySubject: ClassSubject.science,
    );
  }

  @override
  Future<List<StudentModel>> getStudentsInClass() async {
    await Future.delayed(const Duration(milliseconds: 300));
    return List.unmodifiable(_students);
  }

  @override
  Future<void> enrollStudent(StudentModel student) async {
    _students.add(student.copyWith(isEnrolled: true));
  }
}
