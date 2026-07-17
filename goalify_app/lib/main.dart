import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import 'controllers/example_class_controller.dart';
import 'localization/example_school_strings.dart';
import 'routing/example_app_router.dart';
import 'services/example_school_service.dart';
import 'styles/example_app_theme.dart';

/// The entry point for the Flutter application.
///
/// In MAUI, App.xaml.cs and MauiProgram.cs handle initialization and DI.
/// Here, we wrap our app in a `MultiProvider` to inject dependencies down 
/// the widget tree, and we use `MaterialApp.router` for navigation.
void main() {
  runApp(const GoalifyApp());
}

class GoalifyApp extends StatelessWidget {
  const GoalifyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MultiProvider(
      providers: [
        // Register the SchoolService
        Provider<SchoolService>(
          create: (_) => MockSchoolService(),
        ),
        // Register the ClassController which depends on SchoolService
        ChangeNotifierProvider<ClassController>(
          create: (context) => ClassController(context.read<SchoolService>()),
        ),
      ],
      child: MaterialApp.router(
        title: SchoolStrings.appName,
        theme: AppTheme.lightTheme,
        // We hand off routing entirely to GoRouter
        routerConfig: AppRouter.router,
      ),
    );
  }
}
