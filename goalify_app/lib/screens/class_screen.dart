import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import '../controllers/class_controller.dart';
import '../localization/school_strings.dart';
import '../shared_widgets/primary_button.dart';

/// The main screen displaying the teacher and students.
///
/// Similar to a ContentPage in MAUI. Thanks to the `provider` package, 
/// we no longer need a StatefulWidget or an AnimatedBuilder. We simply 
/// call `context.watch<ClassController>()` to reactively rebuild this 
/// widget whenever the controller calls `notifyListeners()`.
class ClassScreen extends StatelessWidget {
  const ClassScreen({super.key});

  @override
  Widget build(BuildContext context) {
    // This watches the controller injected higher up in the widget tree.
    final controller = context.watch<ClassController>();

    return Scaffold(
      appBar: AppBar(
        title: const Text(SchoolStrings.classRosterTitle),
      ),
      body: _buildBody(controller),
      floatingActionButton: PrimaryButton(
        label: SchoolStrings.enrollButton,
        // context.read is used for calling methods without listening to updates
        onPressed: () => context.read<ClassController>().enrollNewStudent(),
      ),
    );
  }

  Widget _buildBody(ClassController controller) {
    if (controller.isLoading) {
      return const Center(child: CircularProgressIndicator());
    }

    final teacher = controller.teacher;

    return Column(
      crossAxisAlignment: CrossAxisAlignment.stretch,
      children: [
        if (teacher != null)
          Padding(
            padding: const EdgeInsets.all(16.0),
            child: Text(
              '${SchoolStrings.teacherLabel} ${teacher.name} (${teacher.primarySubject.name})',
              style: const TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
            ),
          ),
        const Divider(),
        Expanded(
          child: ListView.builder(
            itemCount: controller.students.length,
            itemBuilder: (context, index) {
              final student = controller.students[index];
              return ListTile(
                title: Text(student.name),
                trailing: student.isEnrolled 
                    ? const Icon(Icons.school, color: Colors.green) 
                    : null,
              );
            },
          ),
        ),
      ],
    );
  }
}
