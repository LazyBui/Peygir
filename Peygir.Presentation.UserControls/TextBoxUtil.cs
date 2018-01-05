using System;
using System.Windows.Forms;

namespace Peygir.Presentation.UserControls {
	internal static class TextBoxUtil {
		public static void TextBoxKeyDown(object sender, KeyEventArgs e) {
			var casted = (TextBox)sender;
			switch (e.KeyCode) {
				case Keys.Tab: {
					if (casted.ReadOnly)
						break;

					// We want tab indentation behavior as well as tab de-indentation
					// It's also nice if it works on a multiline basis
					var lines = casted.Lines;
					bool isShift = e.Shift;

					var selBegin = casted.SelectionStart;
					var selEnd = casted.SelectionStart + casted.SelectionLength;
					var beginLine = -1;
					var endLine = -1;
					var beginLinePos = -1;
					var endLinePos = -1;
					var consumedLength = 0;
					var selLength = casted.SelectionLength;

					for (var i = 0; i < lines.Length; i++) {
						var line = lines[i];

						if (selBegin >= consumedLength && (line.Length + consumedLength) >= selBegin) {
							beginLine = i;
							beginLinePos = consumedLength;
						}
						if (selEnd >= consumedLength && (line.Length + consumedLength) >= selEnd) {
							endLine = i;
							endLinePos = consumedLength;
							break;
						}
						consumedLength += line.Length + Environment.NewLine.Length;
					}
					if (endLine == -1)
						endLine = lines.Length - 1;

					var isMultiline = (endLine - beginLine) > 0;
					if (isMultiline) {
						// Multiline may need a bit of work
						if (isShift) {
							var moved = 0;
							bool movedFromFirstLine = false;
							bool tabIsFirstSelectionCharacter = false;
							for (var i = beginLine; i <= endLine; i++) {
								if (i == endLine && endLinePos == selEnd)
									break;

								var line = lines[i];
								if (line.Length > 0 && line[0] == '\t') {
									lines[i] = line.Remove(0, 1);
									// If we have a partial selection on the first line and we're removing a tab
									// We'll have to re-add that to the final length, otherwise we'll be short one character
									// It must be done here because we may not remove a tab at all from the first line
									if (i == beginLine) {
										movedFromFirstLine = true;
										tabIsFirstSelectionCharacter = IsInlineWhitespace(line[0]);
									}
									if (i != beginLine || beginLinePos == selBegin)
										moved++;
								}
							}

							UglyUndoHack(
								casted,
								string.Join(Environment.NewLine, lines),
								movedFromFirstLine &&
								beginLinePos != selBegin &&
								(!tabIsFirstSelectionCharacter || moved == 0) ?
									selBegin - 1 :
									selBegin,
								selLength - moved);
						}
						else {
							//bool insertToFirstLine = false;
							for (var i = beginLine; i <= endLine; i++) {
								if (i == endLine && endLinePos == selEnd)
									break;
								if (lines[i].Length == 0)
									continue;
								lines[i] = "\t" + lines[i];
								// Need to do this because a tab might not be added to the first line
								//if (i == beginLine && beginLinePos > 0)
								//	insertToFirstLine = true;
							}

							UglyUndoHack(
								casted,
								string.Join(Environment.NewLine, lines),
								beginLinePos == selBegin || casted.Text[selBegin - 1] == '\t' ?
									selBegin :
									selBegin + 1,
								selLength + endLine - beginLine +
								(endLinePos == selEnd ? 0 : 1));
						}
					}
					else {
						string lineTest = lines[beginLine];
						if (selLength == lineTest.Length && selLength > 0) {
							if (isShift) {
								// We know by virtue of getting here that the line has at least 1 character, otherwise selLength could not match the line length due to > 0
								if (lineTest[0] != '\t') {
									// TODO FIXME
									// Not sure how VS handles this case when there are spaces at the beginning
									// Or a differing number of spaces than tabs
									// It appears to be the case that it treats *up to* 4 spaces as a single tab
									goto Suppress;
								}

								UglyUndoHack(
									casted,
									casted.Text.Remove(selBegin, 1),
									selBegin,
									selLength - 1);
							}
							else {
								UglyUndoHack(
									casted,
									casted.Text.Remove(selBegin) +
									"\t" +
									casted.Text.Remove(0, selBegin),
									selBegin,
									selLength + 1);
							}
						}
						else if (selLength > 0) {
							if (isShift) {
								if (selBegin == 0) {
									goto Suppress;
								}
								var previousChar = casted.Text[selBegin - 1];
								if (!IsInlineWhitespace(previousChar)) {
									goto Suppress;
								}

								UglyUndoHack(
									casted,
									casted.Text.Remove(selBegin - 1, 1),
									selBegin - 1,
									selLength);
							}
							else {
								UglyUndoHack(
									casted,
									casted.Text.Remove(selBegin) +
									"\t" +
									casted.Text.Remove(0, selEnd),
									selBegin + 1,
									0);
							}
						}
						else {
							if (isShift) {
								if (selBegin == 0) {
									goto Suppress;
								}
								var previousChar = casted.Text[selBegin - 1];
								if (!IsInlineWhitespace(previousChar)) {
									goto Suppress;
								}

								UglyUndoHack(
									casted,
									casted.Text.Remove(selBegin - 1, 1),
									selBegin - 1,
									selLength);
							}
							else {
								UglyUndoHack(
									casted,
									(selBegin == casted.Text.Length ?
										casted.Text :
										casted.Text.Remove(selBegin)) +
									"\t" +
									casted.Text.Remove(0, selEnd),
									selBegin + 1,
									selLength);
							}
						}
					}

					Suppress: {
						e.Handled = true;
						e.SuppressKeyPress = true;
					}
					break;
				}
				case Keys.A:
					if (!e.Control)
						break;
					casted.SelectAll();
					e.Handled = true;
					break;
				case Keys.Back:
					if (!e.Control)
						break;

					// Prevent the obnoxious default behavior of inserting a box
					// Also if this isn't readonly, give some useful word-delete behavior
					if (!casted.ReadOnly) {
						if (casted.SelectionLength > 0) {
							// We should treat this as a delete of specifically what's selected, no more, no less
							int selectionStart = casted.SelectionStart;
							UglyUndoHack(
								casted,
								casted.Text.Remove(selectionStart, casted.SelectionLength),
								selectionStart,
								0);
						}
						else {
							// We should delete the last full "word" plus any spaces in our way
							int deleteEndIndex = casted.SelectionStart;
							int deleteBeginIndex;

							bool hitWord = false;
							bool hitAnySpace = false;
							for (deleteBeginIndex = deleteEndIndex - 1; deleteBeginIndex > 0; deleteBeginIndex--) {
								var c = casted.Text[deleteBeginIndex];
								if (hitWord) {
									if (IsBreakBeforeWordDeleteCharacter(c)) {
										deleteBeginIndex++;
										break;
									}
									else if (IsBreakOnWordDeleteCharacter(c)) {
										break;
									}
								}
								else if (!IsWhitespace(c)) {
									hitWord = true;
								}
								else if (IsNewline(c)) {
									// We only want to delete up to the newline
									// But that's if we're not starting from the beginning of the line
									if (hitAnySpace) {
										deleteBeginIndex++;
										break;
									}
								}
								else {
									hitAnySpace = true;
								}
							}

							if (deleteBeginIndex > -1) {
								UglyUndoHack(
									casted,
									casted.Text.Remove(
										deleteBeginIndex,
										deleteEndIndex - deleteBeginIndex),
									deleteBeginIndex,
									0);
							}
							else {
								// TODO FIXME?
							}
						}
					}
					e.Handled = true;
					e.SuppressKeyPress = true;
					break;
			}
		}

		private static void UglyUndoHack(TextBox input, string newText, int selectionStart, int selectionLength) {
			input.SelectAll();
			// Hack to get undo behavior
			// TODO FIXME
			// Eventually, write a textbox wrapper that supports better undo functionality because this is hacky and has usability downsides
			input.Paste(newText);
			input.SelectionStart = selectionStart;
			input.SelectionLength = selectionLength;
			input.ScrollToCaret();
		}

		private static bool IsBreakBeforeWordDeleteCharacter(char c) {
			switch (c) {
				case ' ':
				case '\t':
				case '\r':
				case '\n':
					return true;
			}
			return false;
		}

		private static bool IsBreakOnWordDeleteCharacter(char c) {
			switch (c) {
				case '(':
				case '[':
				case '{':
				case '.':
				case ',':
				case '\\':
				case '/':
					return true;
			}
			return false;
		}

		private static bool IsNewline(char c) {
			return c == '\r' || c == '\n';
		}

		private static bool IsInlineWhitespace(char c) {
			return c == ' ' || c == '\t';
		}

		private static bool IsWhitespace(char c) {
			return c == ' ' || c == '\t' || c == '\r' || c == '\n';
		}
	}
}
