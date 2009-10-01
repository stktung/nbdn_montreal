param($message,$working_branch,$branch_to_merge="development")

. .\git_utils.ps1

commit($message)
merge($working_branch,$branch_to_merge)
push($working_branch)


