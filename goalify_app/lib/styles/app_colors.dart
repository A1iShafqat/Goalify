import 'package:flutter/material.dart';

/// Centralized design tokens for colors.
///
/// In MAUI, you would often define these in a ResourceDictionary in App.xaml.
/// In Flutter, we commonly use static const variables or an inherited Theme 
/// extension. Here we define our base color palette as static constants to 
/// avoid inline hex values throughout the app.
class AppColors {
  static const Color primary = Color(0xFF3B82F6); // Example blue
  static const Color schoolBranding = Color(0xFF10B981); // Emerald green
  static const Color background = Color(0xFFF3F4F6);
  static const Color textMain = Color(0xFF111827);
  static const Color textSecondary = Color(0xFF6B7280);
  
  // Prevent instantiation
  AppColors._();
}
