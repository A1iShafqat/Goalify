import 'package:flutter/material.dart';
import 'app_colors.dart';

/// Centralized theme configuration for the application.
///
/// In MAUI, you would define implicit styles in App.xaml to apply 
/// universally (e.g., setting the global BackgroundColor for Buttons).
/// In Flutter, we construct a `ThemeData` object and pass it to the 
/// MaterialApp, which ensures standard widgets inherit these styles automatically.
class AppTheme {
  static ThemeData get lightTheme {
    return ThemeData(
      colorScheme: ColorScheme.fromSeed(
        seedColor: AppColors.primary,
        primary: AppColors.primary,
        surface: AppColors.background,
      ),
      scaffoldBackgroundColor: AppColors.background,
      elevatedButtonTheme: ElevatedButtonThemeData(
        style: ElevatedButton.styleFrom(
          backgroundColor: AppColors.schoolBranding, // Globally apply branding color
          foregroundColor: Colors.white,
          padding: const EdgeInsets.symmetric(horizontal: 24, vertical: 12),
          shape: RoundedRectangleBorder(
            borderRadius: BorderRadius.circular(8),
          ),
        ),
      ),
      appBarTheme: const AppBarTheme(
        backgroundColor: AppColors.primary,
        foregroundColor: Colors.white,
      ),
    );
  }

  // Prevent instantiation
  AppTheme._();
}
