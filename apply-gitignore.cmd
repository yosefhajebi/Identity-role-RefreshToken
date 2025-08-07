@echo off
echo 🔄 Removing tracked files that should be ignored...
git rm -r --cached .

echo 📦 Re-adding files based on updated .gitignore...
git add .

echo ✅ Committing changes...
git commit -m "Apply .gitignore and remove tracked build artifacts"

echo 🎉 Done! Your .gitignore is now in effect.
pause
