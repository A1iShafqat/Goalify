import 'package:flutter/material.dart';
import '../data/models/example_student_model.dart';
import '../data/models/example_teacher_model.dart';
import '../services/example_school_service.dart';

/// Manages the state for the Class Screen.
///
/// This is the Flutter equivalent of a MAUI ViewModel. We use 
/// `ChangeNotifier` to hold state and notify listeners.
class ClassController extends ChangeNotifier {
  final SchoolService _schoolService;

  bool _isLoading = true;
  TeacherModel? _teacher;
  List<StudentModel> _students = [];

  ClassController(this._schoolService) {
    _loadData();
  }

  bool get isLoading => _isLoading;
  TeacherModel? get teacher => _teacher;
  List<StudentModel> get students => _students;

  /// Fetches teacher and student data.
  Future<void> _loadData() async {
    _isLoading = true;
    notifyListeners();

    _teacher = await _schoolService.getTeacherInfo();
    _students = await _schoolService.getStudentsInClass();

    _isLoading = false;
    notifyListeners();
  }

  /// Enrolls a new student and refreshes the list.
  Future<void> enrollNewStudent() async {
    final newStudent = StudentModel(
      id: DateTime.now().millisecondsSinceEpoch.toString(),
      name: 'New Student',
    );
    
    await _schoolService.enrollStudent(newStudent);
    await _loadData();
  }
}
