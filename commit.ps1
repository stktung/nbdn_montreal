param($commit_message)

if (!$commit_message) {
   'usage: commit.ps1 <commit message>'
   exit 1
}

git add -A
git commit -m $commit_message