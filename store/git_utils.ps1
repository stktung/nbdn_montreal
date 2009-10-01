function merge($working_branch = "master",$branch_to_merge)
{
  git checkout $working_branch
  git merge $branch_to_merge
}

function commit($message)
{
  git add -A
  if ($message -eq $null)
  {
    git commit
    exit;
  }
  git commit -m $message
}

function push($branch)
{
  if ($branch -eq $null)
  {
    git push
    exit;
  }
  git push origin $branch
}

function pull($remote,$remote_branch,$branch_to_pull_to)
{
  git checkout -b $branch_to_pull_to
  git pull $remote $remote_branch
}

