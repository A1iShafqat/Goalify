import 'package:flutter/material.dart';

/// A reusable button widget.
///
/// Notice how we no longer define colors or shapes directly in the 
/// button's style. Since we implemented `AppTheme`, this `ElevatedButton` 
/// will automatically pick up the `AppColors.schoolBranding` background 
/// and rounded corners defined globally, much like implicit XAML styles!
class PrimaryButton extends StatelessWidget {
  final String label;
  final VoidCallback onPressed;

  const PrimaryButton({
    super.key,
    required this.label,
    required this.onPressed,
  });

  @override
  Widget build(BuildContext context) {
    return ElevatedButton(
      onPressed: onPressed,
      child: Text(
        label,
        style: const TextStyle(fontWeight: FontWeight.bold),
      ),
    );
  }
}
