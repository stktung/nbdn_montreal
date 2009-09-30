if ($args.length -neq 1)
{
  "Usage -- pull [remotename]
  exit
}
git checkout development
git pull $args[0] master
