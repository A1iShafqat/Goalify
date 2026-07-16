// This is a basic Flutter widget test.
//
// To perform an interaction with a widget in your test, use the WidgetTester
// utility in the flutter_test package. For example, you can send tap and scroll
// gestures. You can also use WidgetTester to find child widgets in the widget
// tree, read text, and verify that the values of widget properties are correct.

import 'package:flutter/material.dart';
import 'package:flutter_test/flutter_test.dart';

import 'package:goalify_app/main.dart';
import 'package:goalify_app/localization/school_strings.dart';

void main() {
  testWidgets('ClassScreen smoke test', (WidgetTester tester) async {
    // Build our app and trigger a frame.
    await tester.pumpWidget(const GoalifyApp());

    // The MockSchoolService has a 300ms delay. We pumpAndSettle to wait for 
    // the Future to complete and the UI to update from CircularProgressIndicator
    // to the actual list.
    await tester.pumpAndSettle();

    // Verify that the AppBar title is present.
    expect(find.text(SchoolStrings.classRosterTitle), findsOneWidget);

    // Verify that the 'Enroll New Student' button is present.
    expect(find.text(SchoolStrings.enrollButton), findsOneWidget);
  });
}
