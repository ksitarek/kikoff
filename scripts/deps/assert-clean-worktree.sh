#!/usr/bin/env bash

function assert_clean_worktree() {
  echo "Checking git worktree is clean..."
  if ! git -C "${REPO_ROOT}" diff --quiet 2>/dev/null || ! git -C "${REPO_ROOT}" diff --cached --quiet 2>/dev/null; then
    echo "Error: Git worktree is not clean. Please commit or stash your changes before running this script." >&2
    exit 1
  fi

  if [[ -n "$(git -C "${REPO_ROOT}" ls-files --others --exclude-standard 2>/dev/null)" ]]; then
    echo "Error: Git worktree has untracked files. Please commit or stash your changes before running this script." >&2
    exit 1
  fi

  echo "  Worktree is clean."
}
