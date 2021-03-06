// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Web.LibraryManager.LibraryNaming;

namespace Microsoft.Web.LibraryManager.Test
{
    [TestClass]
    public class VersionedLibraryNamingSchemeTest
    {
        [DataTestMethod]
        [DataRow("jquery@3.3.1", "jquery", "3.3.1")]
        [DataRow("@angular/cli@1.0.0", "@angular/cli", "1.0.0")]
        [DataRow("My@Random@Library@1.0.0-preview3-final", "My@Random@Library", "1.0.0-preview3-final")]
        [DataRow("@MyLibraryWithoutVersion", "@MyLibraryWithoutVersion", "")]
        [DataRow("Library@Version", "Library", "Version")]
        [DataRow("Partial@", "Partial@", "")]
        [DataRow(null, "", "")]
        [DataRow("", "", "")]
        public void GetLibraryNameAndVersion(string libraryId, string expectedName, string expectedVersion)
        {
            var namingScheme = new VersionedLibraryNamingScheme();
            (string name, string version) = namingScheme.GetLibraryNameAndVersion(libraryId);

            Assert.AreEqual(expectedName, name);
            Assert.AreEqual(expectedVersion, version);
        }

        [DataTestMethod]
        [DataRow("jquery", "3.3.1", "jquery@3.3.1")]
        [DataRow("@angular/cli", "1.0.0", "@angular/cli@1.0.0")]
        [DataRow("My@Random@Library", "1.0.0-preview3-final", "My@Random@Library@1.0.0-preview3-final")]
        [DataRow("@MyLibraryWithoutVersion", "", "@MyLibraryWithoutVersion")]
        [DataRow("Library", "Version", "Library@Version")]
        [DataRow("", "", "")]
        [DataRow(null, null, "")]
        [DataRow("Partial", "", "Partial")]
        [DataRow("Partial@", "", "Partial@")]
        public void GetLibraryId(string name, string version, string expectedLibraryId)
        {
            var namingScheme = new VersionedLibraryNamingScheme();
            string libraryId = namingScheme.GetLibraryId(name, version);

            Assert.AreEqual(expectedLibraryId, libraryId);
        }
    }
}
