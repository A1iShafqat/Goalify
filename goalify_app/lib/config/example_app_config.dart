/// Centralized configuration for the school environment.
///
/// In MAUI, you might use appsettings.json. In Flutter, we define a 
/// simple static class for global read-only settings.
class AppConfig {
  /// Whether the app is running in a mock/test mode.
  static const bool useMockData = true;

  /// The maximum number of students allowed per class.
  static const int maxStudentsPerClass = 30;

  // Prevent instantiation.
  AppConfig._();
}
