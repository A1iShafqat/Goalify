/// Utility class for formatting dates across the app.
///
/// Similar to static utility classes in C#, we use static methods here.
class DateFormatter {
  /// Formats a date to a simple 'YYYY-MM-DD' string.
  static String formatToStandardDate(DateTime date) {
    final year = date.year.toString();
    final month = date.month.toString().padLeft(2, '0');
    final day = date.day.toString().padLeft(2, '0');
    
    return '$year-$month-$day';
  }

  // Prevent instantiation
  DateFormatter._();
}
