import 'package:go_router/go_router.dart';
import '../screens/class_screen.dart';

/// Centralized declarative routing configuration.
///
/// In MAUI, you use AppShell to define "//routes". In modern Flutter, 
/// the `go_router` package provides robust routing, deep-linking, 
/// and route guarding capabilities.
class AppRouter {
  static final GoRouter router = GoRouter(
    initialLocation: '/',
    routes: [
      GoRoute(
        path: '/',
        builder: (context, state) => const ClassScreen(),
      ),
    ],
  );

  // Prevent instantiation
  AppRouter._();
}
